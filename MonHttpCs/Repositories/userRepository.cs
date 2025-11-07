// Repositories/UserRepository.cs
using MonHttpCs.Models;

namespace MonHttpCs.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository()
    {
        _entities = new List<User>
        {
            new User { Id = 1, Name = "Alice", Age = 30, Email = "alice@email.com" },
            new User { Id = 2, Name = "Bob", Age = 25, Email = "bob@email.com" },
            new User { Id = 3, Name = "Charlie", Age = 35, Email = "charlie@email.com" }
        };
    }

    public Task<User?> GetByNameAsync(string name)
    {
        var user = _entities.FirstOrDefault(u => 
            u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(user);
    }

    public Task<IEnumerable<User>> GetUsersByAgeRangeAsync(int minAge, int maxAge)
    {
        var users = _entities.Where(u => u.Age >= minAge && u.Age <= maxAge);
        return Task.FromResult(users);
    }
}