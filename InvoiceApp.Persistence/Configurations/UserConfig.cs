using InvoiceApp.Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Persistence.Configurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.UserId);

        builder.Property(x => x.UserName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.PasswordHash).IsRequired();

        builder.HasMany(x => x.Customers)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);

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
            UserId = 4,
            UserName = "user",
            PasswordHash = "fcb4864a04e0f5a7f301d4d3d366cf812a30c51dd3fae0d176e1de55294e3c6d", // userPassword123
            RecordDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
        },
        new User
        {
            UserId = 2,
            UserName = "yildiz",
            PasswordHash = "fcb4864a04e0f5a7f301d4d3d366cf812a30c51dd3fae0d176e1de55294e3c6d",
            RecordDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
        },
        new User
        {
            UserId = 3,
            UserName = "cinar",
            PasswordHash = "fcb4864a04e0f5a7f301d4d3d366cf812a30c51dd3fae0d176e1de55294e3c6d",
            RecordDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
        });
    }
}