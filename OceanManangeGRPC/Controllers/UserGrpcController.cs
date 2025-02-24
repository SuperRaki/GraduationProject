using Grpc.Core;
using OceanManangeGRPC.Services;

namespace OceanManangeGRPC.Controllers;

public class UserGrpcController :UserService.UserServiceBase {
    private readonly IUserService _userService;

    public UserGrpcController(IUserService userService) {
        _userService = userService;
    }

    public override async Task<GetUserResponse> GetUserById(GetUserRequest request, ServerCallContext context) {
        var user = await _userService.GetUserByIdAsync(request.Id);
        return new GetUserResponse {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }

    public override async Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context) {
        var userId = await _userService.CreateUserAsync(request.Name, request.Email);
        return new CreateUserResponse { Id = userId };
    }
}