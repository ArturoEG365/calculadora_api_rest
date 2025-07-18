namespace WSArtemisaApi.DTOs
{
    public class AuthRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Guid CardBrandId { get; set; }
        public decimal Wallet { get; set; }
    }
}
