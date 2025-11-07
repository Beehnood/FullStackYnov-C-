using MonHttpCs.Models;
using MonHttpCs.Repositories;

namespace MonHttpCs.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<IEnumerable<User>> GetAllUsersAsync() => _userRepository.GetAllAsync();
    public Task<User?> GetUserByIdAsync(int id) => _userRepository.GetByIdAsync(id);
    public Task<User?> GetUserByNameAsync(string name) => _userRepository.GetByNameAsync(name);
    public Task<IEnumerable<User>> GetUsersByAgeRangeAsync(int min, int max) 
        => _userRepository.GetUsersByAgeRangeAsync(min, max);

    public async Task<User> CreateUserAsync(User user)
    {
        // Génère un ID auto
        var all = await _userRepository.GetAllAsync();
        user.Id = all.Any() ? all.Max(u => u.Id) + 1 : 1;
        return await _userRepository.AddAsync(user);
    }

    public Task<User?> UpdateUserAsync(int id, User user)
    {
        user.Id = id;
        return _userRepository.UpdateAsync(user);
    }

    public Task<bool> DeleteUserAsync(int id) => _userRepository.DeleteAsync(id);
    public Task<int> GetUserCountAsync() => _userRepository.CountAsync();
}