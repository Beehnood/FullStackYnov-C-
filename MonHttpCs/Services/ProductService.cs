using MonHttpCs.Interfaces;
using MonHttpCs.Models;

namespace MonHttpCs.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product?> GetById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task Create(Product product)
        {
            await _productRepository.Insert(product);
        }

        public async Task Update(int id, Product product)
        {
            product.Id = id;
            await _productRepository.Update(product);
        }

        public async Task Delete(int id)
        {
            await _productRepository.Delete(id);
        }
    }
}

