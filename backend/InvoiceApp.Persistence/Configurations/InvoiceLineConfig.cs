using InvoiceApp.Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Persistence.Configurations;

public class InvoiceLineConfig : IEntityTypeConfiguration<InvoiceLine>
{
    public void Configure(EntityTypeBuilder<InvoiceLine> builder)
    {
        builder.HasKey(x => x.InvoiceLineId);

        builder.Property(x => x.ItemName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Price).HasPrecision(18, 2);


        builder.HasData(
        new InvoiceLine
        {
            InvoiceLineId = 1,
            InvoiceId = 1,
            ItemName = "Samsung 27\" Monitör",
            Quentity = 3,
            Price = 250,
            RecordDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
            UserId = 1
        },
        new InvoiceLine
        {
            InvoiceLineId = 2,
            InvoiceId = 1,
            ItemName = "Logitech Kablosuz Mouse",
            Quentity = 6,
            Price = 45,
            RecordDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
            UserId = 1
        },
        new InvoiceLine
        {
            InvoiceLineId = 3,
            InvoiceId = 2,
            ItemName = "Nescafe Classic 100gr",
            Quentity = 10,
            Price = 25,
            RecordDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
            UserId = 2
        },
        new InvoiceLine
        {
            InvoiceLineId = 4,
            InvoiceId = 2,
            ItemName = "Doğuş Rize Çayı 1kg",
            Quentity = 5,
            Price = 55,
            RecordDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
            UserId = 2
        });
    }
}