namespace Web_Shop.Application.DTOs
{
    public class AddUpdateProductDTO
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; }
        public decimal Price { get; set; } = 0!;
        public string Sku { get; set; } = null!;
        public bool IsSkuUpdate { get; set; } = true;
    }
}
