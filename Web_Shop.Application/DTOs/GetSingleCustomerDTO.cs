namespace Web_Shop.Application.DTOs
{
    public class GetSingleCustomerDTO
    {
        public ulong IdCustomer { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateOnly? BirthDate { get; set; }
    }
}
