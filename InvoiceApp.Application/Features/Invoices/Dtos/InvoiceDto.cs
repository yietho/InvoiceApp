using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Invoices.Dtos;

public class InvoiceDto
{
    public int InvoiceId { get; set; }
    public int CustomerId { get; set; }
    public int UserId { get; set; }

    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime RecordDate { get; set; }

    // View'a özel alanlar
    public int LineCount => Lines?.Count ?? 0;
    public List<InvoiceLineDto> Lines { get; set; } = new();
}