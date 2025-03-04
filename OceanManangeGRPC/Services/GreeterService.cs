using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using OceanManangeGRPC;

namespace OceanManangeGRPC.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;

    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        // Configure a channel to use gRPC-Web
        var handler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
        var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
        {
            HttpClient = new HttpClient(handler)
        });

        var client = new Greeter.GreeterClient(channel);
        var response = client.SayHelloAsync(new HelloRequest { Name = ".NET" });
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + response
        });
    }
}