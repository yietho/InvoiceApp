using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Invoices.Dtos;

public class CreateInvoiceDto
{
    public int CustomerId { get; set; }
    public int UserId { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; }
    public List<CreateInvoiceLineDto> Lines { get; set; } = new();
}