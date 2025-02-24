using Microsoft.EntityFrameworkCore;

namespace OceanManangeGRPC.Models;
//数据库实体
public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    {
    }
    //定义表
    public DbSet<User> Users { get; set; }
}

// 示例实体类
public class User {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}