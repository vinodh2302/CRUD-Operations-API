using ProductApi.Context;
using ProductApi.Models;
using ProductApi.Repository;

namespace ProductApi.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<bool> AddProduct(Product p);
        public Task<Product> GetProductsById(int id);
        public Task<IEnumerable<Product>> GetProductsByName(string name);
        public Task<IEnumerable<Product>> SortProductsByNameDescending();
        public Task<int> GetProductsCount();
        public Task<bool> UpdateProduct(Product p);
        public Task<bool> DeleteProduct(string pname);
        public Task<bool> DeleteAll();

    }
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        Task<IEnumerable<Product>> IProductService.GetProducts()
        {
            return _productRepository.GetProducts();
        }

        Task<Product> IProductService.GetProductsById(int id)
        {
            return _productRepository.GetProductsById(id);
        }
        Task<IEnumerable<Product>> IProductService.GetProductsByName(string name)
        {
            return _productRepository.GetProductsByName(name);
        }
        Task<bool> IProductService.AddProduct(Product p)
        {
            return _productRepository.AddProduct(p);
        }
        Task<int> IProductService.GetProductsCount()
        {
            return _productRepository.GetProductsCount();
        }

        Task<bool> IProductService.UpdateProduct(Product p)
        {
            return _productRepository.UpdateProduct(p);
        }
        Task<bool> IProductService.DeleteProduct(string pname)
        {
            return _productRepository.DeleteProduct(pname);
        }
        Task<bool> IProductService.DeleteAll()
        {
            return _productRepository.DeleteAll();
        }
        Task<IEnumerable<Product>> IProductService.SortProductsByNameDescending()
        {
            return _productRepository.SortProducts();
        }


    }

}
