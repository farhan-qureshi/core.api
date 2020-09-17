using core.api.commerce.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace core.api.commerce.Data.Interfaces
{
    public interface ICommerceRepository
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task<IEnumerable<SubProduct>> GetAllSubProductsAsync();
        public Task<Product> GetProductByIdAsync(int id);
        public Task<SubProduct> GetSubProductByIdAsync(int id);
        public Task CreateProductAsync(Product Product);
        public Task CreateSubProductAsync(SubProduct Product);
        public void UpdateProductAsync(Product Product);
        public void UpdateSubProductAsync(SubProduct Product);
        public void DeleteProductAsync(int id);
        public void DeleteSubProductAsync(int id);
    }
}