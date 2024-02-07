using Microsoft.EntityFrameworkCore;
using Web_Shop.Persistence.Repositories;
using Web_Shop.Persistence.Repositories.Interfaces;
using WWSI_Shop.Persistence.MySQL.Context;
using WWSI_Shop.Persistence.MySQL.Model;

namespace Web_Shop.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(WwsishopContext dbContext) : base(dbContext) { }

        public async Task<Product?> GetProductByIdAsync(ulong ProductId)
        {
            return await Entities.FirstOrDefaultAsync(e => e.IdProduct == ProductId);
        }

        public async Task <Product?> GetProductByNameAsync(string ProductName)
        {
            
            return await Entities.FirstOrDefaultAsync(e => e.Name == ProductName);
        }

        public async Task<bool> IsProductSkuExistAsync(string sku)
        {
            return await Entities.AnyAsync(e => e.Sku == sku);
        }

    }
    }

