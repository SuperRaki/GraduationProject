using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using OceanManageGRPC.Protos;
using UserService = OceanManangeGRPC.Services.UserService;

namespace OceanManangeGRPC.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("GetUser")]
    public async Task<IActionResult> GetUser(int id)
    {   
        // 添加日志输出
        Console.WriteLine($"Received GET request for user with ID: {id}");

        var request = new UserRequest { Id = id };
        var response = await _userService.GetUserService(request,null);

        return Ok(response);  // 返回 gRPC 响应
    }
}