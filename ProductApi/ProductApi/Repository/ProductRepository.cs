using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;
using ProductApi.Context;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Repository
{
    public interface IProductRepository
    {
         Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductsById(int id);
        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task<bool> AddProduct(Product p);
        public Task<int> GetProductsCount();
        public Task<IEnumerable<Product>> SortProducts();
        public Task<bool> UpdateProduct(Product p);
        public Task<bool> DeleteProduct(string name);
        public Task<bool> DeleteAll();

    }
    public class ProductRepository : IProductRepository
    {

        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;

        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _productContext.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductsById(int id)
        {
            var products = await _productContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {

               var products = _productContext.Products.Where(pr => pr.Name == name);
            return products;
        }


        public async Task<bool> AddProduct(Product p)
        {
             _productContext.Products.Add(p);
            return _productContext.SaveChanges() > 0;
        }

        public async Task<bool> DeleteProduct(string n)
        {
            var a = _productContext.Products.FirstOrDefault(p1 => p1.Name == n);
            _productContext.Products.Remove(a);
            return _productContext.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAll()
        {
            var a = _productContext.Products.Where(p => p.Id >= 0);
            _productContext.Products.RemoveRange(a);
            return _productContext.SaveChanges() > 0;
        }

        public async Task<int> GetProductsCount()
        {
            return _productContext.Products.Count();
        }

        public async Task<IEnumerable<Product>> SortProducts()
        {
            return _productContext.Products.OrderByDescending(p => p.Name);
        }

        public async Task<bool> UpdateProduct(Product p)
        {
            if(await _productContext.Products.AnyAsync(pr =>pr.Name == p.Name))
            {
                var pr = await _productContext.Products.FirstOrDefaultAsync(pr => pr.Name == p.Name);
                pr.Name = p.Name;
                pr.Description = p.Description;
                pr.Price = p.Price;
                pr.Category = p.Category;

                int succ = await _productContext.SaveChangesAsync();
                if(succ >= 0)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
