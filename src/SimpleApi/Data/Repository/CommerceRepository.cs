using Microsoft.EntityFrameworkCore;
using core.api.commerce.Data.EF;
using core.api.commerce.Data.Interfaces;
using core.api.commerce.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace core.api.commerce.Data
{
    public class CommerceRepository : ICommerceRepository
    {
        private readonly CommerceContext _csContext;

        public CommerceRepository(CommerceContext csContext)
        {
            _csContext = csContext;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _csContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<SubProduct>> GetAllSubProductsAsync()
        {
            return await _csContext.SubProducts.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _csContext.Products.Include(s => s.SubProducts).FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<SubProduct> GetSubProductByIdAsync(int id)
        {
            return await _csContext.SubProducts.FirstOrDefaultAsync(s => s.SubProductId == id);
        }

        public async Task CreateProductAsync(Product product)
        {
            await _csContext.Products.AddAsync(product);
            _csContext.SaveChanges();
        }

        public async Task CreateSubProductAsync(SubProduct subProduct)
        {
            await _csContext.SubProducts.AddAsync(subProduct);
            _csContext.SaveChanges();
        }

        public void UpdateProductAsync(Product product)
        {
            _csContext.Products.Update(product);
            _csContext.SaveChanges();
        }

        public void UpdateSubProductAsync(SubProduct subProduct)
        {
            _csContext.SubProducts.Update(subProduct);
            _csContext.SaveChanges();
        }

        public void DeleteProductAsync(int id)
        {
            _csContext.Products.Remove(new Product { ProductId = id });
            _csContext.SaveChanges();
        }

        public void DeleteSubProductAsync(int id)
        {
            _csContext.SubProducts.Remove(new SubProduct { SubProductId = id });
            _csContext.SaveChanges();
        }
    }
}
