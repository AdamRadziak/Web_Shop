using WWSI_Shop.Persistence.MySQL.Model;

namespace Web_Shop.Persistence.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> IsProductSkuExistAsync(string sku);

        Task<int> GetProductSkuCountAsync(IQueryable<Product> repository, string sku);
    }
}
