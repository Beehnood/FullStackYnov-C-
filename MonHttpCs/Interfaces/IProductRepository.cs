using MonHttpCs.Models;

namespace MonHttpCs.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product?> GetById(int id);
        Task Insert(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }
}
