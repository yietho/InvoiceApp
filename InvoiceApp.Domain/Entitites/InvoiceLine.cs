using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Domain.Entitites;

public class InvoiceLine
{
    public int InvoiceLineId { get; set; }
    public int InvoiceId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public int Quentity { get; set; }
    public decimal Price { get; set; }
    public int UserId { get; set; }
    public DateTime RecordDate { get; set; } = DateTime.UtcNow;
    public User User { get; set; } = null!;

    public Invoice Invoice { get; set; } = null!;
}