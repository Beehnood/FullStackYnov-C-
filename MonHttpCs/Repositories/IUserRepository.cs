// Repositories/IUserRepository.cs
using MonHttpCs.Models;

namespace MonHttpCs.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByNameAsync(string name);
    Task<IEnumerable<User>> GetUsersByAgeRangeAsync(int minAge, int maxAge);
}