using OceanManangeGRPC.Models;
using OceanManangeGRPC.Repositories;

namespace OceanManangeGRPC.Services;

public class UserService : IUserService {
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserByIdAsync(int id) {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task<int> CreateUserAsync(string name, string email) {
        var user = new User { Name = name, Email = email };
        return await _userRepository.CreateUserAsync(user);
    }
}