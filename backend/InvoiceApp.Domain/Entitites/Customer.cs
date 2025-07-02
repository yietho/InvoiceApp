using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Domain.Entitites;

public class Customer
{
    public int CustomerId { get; set; }
    public string TaxNumber { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string EMail { get; set; } = string.Empty;
    public int UserId { get; set; }
    public DateTime RecordDate { get; set; } = DateTime.UtcNow;

    public User User { get; set; } = null!;
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}