using OceanManangeGRPC.Models;

namespace OceanManangeGRPC.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(int id);
    Task<int> CreateUserAsync(User user); 
}