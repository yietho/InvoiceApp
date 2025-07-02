using InvoiceApp.Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Persistence.Configurations;

public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(x => x.InvoiceId);

        builder.Property(x => x.InvoiceNumber).IsRequired().HasMaxLength(50);
        builder.Property(x => x.TotalAmount).HasPrecision(18, 2);

        builder.HasMany(x => x.Lines)
               .WithOne(x => x.Invoice)
               .HasForeignKey(x => x.InvoiceId)
               .OnDelete(DeleteBehavior.Cascade);


        builder.HasData(
        new Invoice
        {
            InvoiceId = 1,
            CustomerId = 1,
            UserId = 1,
            InvoiceNumber = "FTR-2025001",
            InvoiceDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
            TotalAmount = 1020,
            RecordDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
        },
        new Invoice
        {
            InvoiceId = 2,
            CustomerId = 2,
            UserId = 2,
            InvoiceNumber = "FTR-2025002",
            InvoiceDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
            TotalAmount = 525,
            RecordDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
        });
    }
}