// Services/IUserService.cs
using MonHttpCs.Models;

namespace MonHttpCs.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByNameAsync(string name);
    Task<IEnumerable<User>> GetUsersByAgeRangeAsync(int min, int max);
    Task<User> CreateUserAsync(User user);
    Task<User?> UpdateUserAsync(int id, User user);
    Task<bool> DeleteUserAsync(int id);
    Task<int> GetUserCountAsync();
}