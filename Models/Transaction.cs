using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSArtemisaApi.Models
{
    [Table("transactions")]
    public class Transaction
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("from_user_id")]
        public Guid FromUserId { get; set; } 

        [Column("to_user_id")]
        public Guid ToUserId { get; set; } 

        [Column("amount")]
        public decimal Amount { get; set; } 

        [Column("transaction_time")]
        public DateTime TransactionTime { get; set; } = DateTime.UtcNow;

        [Column("status")]
        public string Status { get; set; }

        [Column("from_card_brand_id")]
        public Guid FromCardBrandId { get; set; }

        [Column("to_card_brand_id")]
        public Guid ToCardBrandId { get; set; } 

        [ForeignKey("FromCardBrandId")]
        public virtual CardBrand FromCardBrand { get; set; }

        [ForeignKey("ToCardBrandId")]
        public virtual CardBrand ToCardBrand { get; set; }

        [ForeignKey("FromUserId")]
        public virtual User FromUser { get; set; }

        [ForeignKey("ToUserId")]
        public virtual User ToUser { get; set; }
    }
}
