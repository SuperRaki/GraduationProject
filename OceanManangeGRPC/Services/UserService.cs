using Grpc.Core;
using OceanManageGRPC.Protos;
using OceanManangeGRPC.Models;
using OceanManangeGRPC.Repositories;

namespace OceanManangeGRPC.Services;

public class UserService : OceanManageGRPC.Protos.UserService.UserServiceBase
{
    public Task<UserResponse> GetUserService(UserRequest request, ServerCallContext context)
    {
        var user = new UserResponse
        {
            Id = request.Id,
            Name = "张三",
            Email = "zhangsan@example.com"
        };

        return Task.FromResult(user);
    }
}