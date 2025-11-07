using MonHttpCs.Models;

namespace MonHttpCs.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product?> GetById(int id);
        Task Create(Product product);
        Task Update(int id, Product product);
        Task Delete(int id);
    }
}
