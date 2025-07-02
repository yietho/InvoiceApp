using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Domain.Entitites;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime RecordDate { get; set; } = DateTime.UtcNow;

    // Seed datalar için gösterim amaçlı oluşturulmuştur.
    // Gerçek zamanlı projeler için kesinlikle uygun değildir.
    public bool IsPlainPassword { get; set; } = false; 
    public Customer Customer { get; set; } = null!;
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    public ICollection<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();
}