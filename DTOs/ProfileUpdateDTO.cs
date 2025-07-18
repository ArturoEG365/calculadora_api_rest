namespace WSArtemisaApi.DTOs
{
    public class ProfileUpdateDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Guid? CardBrandId { get; set; }
        public decimal? Wallet { get; set; }
    }
}
