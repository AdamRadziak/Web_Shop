namespace Web_Shop.Persistence.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> IsProductSkuExistAsync(string sku);
    }
}
