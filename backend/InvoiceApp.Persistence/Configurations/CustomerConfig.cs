using InvoiceApp.Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Persistence.Configurations;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.CustomerId);

        builder.Property(x => x.TaxNumber).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(150);

        builder.HasMany(x => x.Invoices)
               .WithOne(x => x.Customer)
               .HasForeignKey(x => x.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.User)
               .WithOne(x => x.Customer)
               .HasForeignKey<Customer>(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new Customer
            {
                CustomerId = 1,
                TaxNumber = "1234567890",
                Title = "Yıldızlar Elektronik A.Ş.",
                Address = "İkitelli OSB Mah. Atatürk Blv. No:45, Başakşehir / İstanbul",
                EMail = "info@yildizlar.com.tr",
                UserId = 1,
                RecordDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
            },
            new Customer
            {
                CustomerId = 2,
                TaxNumber = "0987654321",
                Title = "Çınar Gıda Tic. Ltd. Şti.",
                Address = "Güzelyalı Mah. Sahil Cad. No:12, Konak / İzmir",
                EMail = "satis@cinar-gida.com",
                UserId = 2,
                RecordDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
            });
    }
}