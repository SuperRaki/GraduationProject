using OceanManangeGRPC.Models;

namespace OceanManangeGRPC.Repositories;

public class UserRepository:IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<User> GetUserByIdAsync(int id) {
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task<int> CreateUserAsync(User user) {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user.Id;
    }
}