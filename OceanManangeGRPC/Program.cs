using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OceanManangeGRPC.Models;
using OceanManangeGRPC.Repositories;
using OceanManangeGRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

//依赖注入
builder.Services.AddScoped<UserService>();

// 添加 Swagger 支持
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "gRPC with REST API",
        Version = "v1"
    });
});

// 添加 CORS，允许前端访问
builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
}));

// 添加数据库上下文（示例）
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers(); // 添加控制器服务

var app = builder.Build();

app.MapControllers();  // 确保控制器已映射

// 配置 CORS 中间件
app.UseCors("AllowAll");  // 使用配置好的 CORS 策略

// 启用 Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "gRPC with REST API");
    c.RoutePrefix = string.Empty; // 访问 http://localhost:5182 直接打开 Swagger
});

// 启用 gRPC-Web
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

// 映射 gRPC 服务，启用 gRPC-Web 并应用 CORS
app.MapGrpcService<GreeterService>().EnableGrpcWeb().RequireCors("AllowAll");
app.MapGrpcService<UserService>().EnableGrpcWeb().RequireCors("AllowAll");

// 提供 REST API 端点（如果有）
app.MapGet("/", () => "This is a gRPC server with Swagger enabled.");

app.Run();