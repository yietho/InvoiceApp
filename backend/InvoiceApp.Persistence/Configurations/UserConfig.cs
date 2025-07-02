using InvoiceApp.Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Persistence.Configurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.UserId);

        builder.Property(x => x.UserName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.PasswordHash).IsRequired();

        builder.HasOne(u => u.Customer)
               .WithOne(c => c.User)
               .HasForeignKey<Customer>(c => c.UserId);

        builder.HasMany(x => x.Invoices)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.InvoiceLines)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(

        new User
        {
            UserId = 1,
            UserName = "yildiz",
            PasswordHash = "parola123",
            RecordDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
            IsPlainPassword = true
        },
        new User
        {
            UserId = 2,
            UserName = "cinar",
            PasswordHash = "parola123",
            RecordDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
            IsPlainPassword = true
        });
    }
}