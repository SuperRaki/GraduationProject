using OceanManangeGRPC.Models;

namespace OceanManangeGRPC.Services;

public interface IUserService
{
    Task<User> GetUserByIdAsync(int id);
    Task<int> CreateUserAsync(string name, string email);
}