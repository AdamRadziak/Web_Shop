using WWSI_Shop.Persistence.MySQL.Model;

namespace Web_Shop.Persistence.Repositories.Interfaces
{
    public interface IProductRepository
    {

        Task<bool> IsProductSkuExistAsync(string ProductName);
        Task<Product?> GetProductByIdAsync(ulong ProductId);
        Task <Product?> GetProductByNameAsync(string ProductName);
    }
}
