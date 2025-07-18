using Microsoft.EntityFrameworkCore;
using WSArtemisaApi.Models;

namespace WSArtemisaApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<CardBrand> CardBrands { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("branch");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.BusinessName).HasColumnName("business_name");
                entity.Property(e => e.UniqueID).HasColumnName("unique_id");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<CardBrand>(entity =>
            {
                entity.ToTable("card_brand");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.BrandName).HasColumnName("brandName");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Merchant>(entity =>
            {
                entity.ToTable("merchant");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.LegalName).HasColumnName("legal_name");
                entity.Property(e => e.Rfc).HasColumnName("rfc");
                entity.Property(e => e.Identifier).HasColumnName("identifier");
                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.LastName).HasColumnName("last_name");
                entity.Property(e => e.CardBrandId).HasColumnName("card_brand_id");
                entity.Property(e => e.Wallet).HasColumnName("wallet");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.HasOne(e => e.CardBrand)
                    .WithMany()
                    .HasForeignKey(e => e.CardBrandId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transactions");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.FromUserId).HasColumnName("from_user_id");
                entity.Property(e => e.ToUserId).HasColumnName("to_user_id");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.TransactionTime).HasColumnName("transaction_time").HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.FromCardBrandId).HasColumnName("from_card_brand_id");
                entity.Property(e => e.ToCardBrandId).HasColumnName("to_card_brand_id");

                entity.HasOne(e => e.FromUser)
                    .WithMany()
                    .HasForeignKey(e => e.FromUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.ToUser)
                    .WithMany()
                    .HasForeignKey(e => e.ToUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.FromCardBrand)
                    .WithMany()
                    .HasForeignKey(e => e.FromCardBrandId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.ToCardBrand)
                    .WithMany()
                    .HasForeignKey(e => e.ToCardBrandId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
