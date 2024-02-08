namespace Web_Shop.Application.DTOs
{
    public class GetSingleProductDTO
    {
        public ulong IdProduct { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string sku { get; set; } = null!;

    }
}
