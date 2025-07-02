using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Invoices.Dtos;

public class UpdateInvoiceLineDto
{
    public string ItemName { get; set; } = string.Empty;
    public int Quentity { get; set; }
    public decimal Price { get; set; }
    public int UserId { get; set; }
}
