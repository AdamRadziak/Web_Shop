using WWSI_Shop.Persistence.MySQL.Model;

namespace Web_Shop.Persistence.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task <bool> IsProductIdExistAsync(ulong ProductId);

        Task<bool> IsProductNameExistAsync(string ProductName);
        Task<Product?> GetProductByIdAsync(ulong ProductId);
        Task<Product?> GetProductByNameAsync(string ProductName);
    }
}
