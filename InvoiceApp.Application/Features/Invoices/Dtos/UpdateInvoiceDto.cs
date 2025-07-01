using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Invoices.Dtos;

public class UpdateInvoiceDto
{
    public int InvoiceId { get; set; }
    public int CustomerId { get; set; }
    public int UserId { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; }
    public List<UpdateInvoiceLineDto> Lines { get; set; } = new();
}