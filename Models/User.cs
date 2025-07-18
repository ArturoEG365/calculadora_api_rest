using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSArtemisaApi.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

       
        [Column("name")]
        public string? Name { get; set; }

        [Column("last_name")]
        public string? LastName { get; set; }

        [Column("card_brand_id")]
        public Guid CardBrandId { get; set; } 

        [Column("wallet")]
        public decimal Wallet { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [ForeignKey("CardBrandId")]
        public virtual CardBrand CardBrand { get; set; }
    }
}
