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

        Task<Product?> IProductRepository.GetProductByIdAsync(ulong ProductId)
        {
            return Entities.FirstOrDefaultAsync(e => e.Equals(ProductId));
        }

        Task <Product?> IProductRepository.GetProductByNameAsync(string ProductName)
        {
            
            return Entities.FirstOrDefaultAsync(e => e.Equals(ProductName));
        }

        Task<bool> IProductRepository.IsProductIdExistAsync(ulong ProductId)
        {
            return Entities.AnyAsync(e => e.IdProduct == ProductId);
        }

        Task<bool> IProductRepository.IsProductNameExistAsync(string ProductName)
        {
            return Entities.AnyAsync(e => e.Name == ProductName);
        }
    }
    }

