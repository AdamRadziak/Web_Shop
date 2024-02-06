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
            return await Entities.FirstOrDefaultAsync(e => e.Equals(ProductId));
        }

        public async Task <Product?> GetProductByNameAsync(string ProductName)
        {
            
            return await Entities.FirstOrDefaultAsync(e => e.Equals(ProductName));
        }

        public async Task<bool> IsProductIdExistAsync(ulong ProductId)
        {
            return await Entities.AnyAsync(e => e.IdProduct == ProductId);
        }

        public async Task<bool> IsProductNameExistAsync(string ProductName)
        {
            return await Entities.AnyAsync(e => e.Name == ProductName);
        }
    }
    }

