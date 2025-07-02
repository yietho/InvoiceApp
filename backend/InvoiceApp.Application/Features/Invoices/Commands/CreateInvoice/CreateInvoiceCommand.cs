using InvoiceApp.Application.Features.Invoices.Dtos;
using InvoiceApp.Domain.Entitites;
using InvoiceApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Invoices.Commands.CreateInvoice;

public class CreateInvoiceCommand : IRequest<int> 
{
    public CreateInvoiceDto Invoice { get; set; }

    public CreateInvoiceCommand(CreateInvoiceDto invoice)
    {
        Invoice = invoice;
    }
}

public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, int>
{
    private readonly IAppDbContext _context;

    public CreateInvoiceCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Invoice;

        var invoiceLines = dto.Lines.Select(x => new InvoiceLine
        {
            ItemName = x.ItemName,
            Quentity = x.Quentity,
            Price = x.Price,
            UserId = x.UserId,
            RecordDate = DateTime.UtcNow
        }).ToList();

        decimal totalAmount = invoiceLines.Sum(line => line.Quentity * line.Price);

        var invoice = new Invoice
        {
            CustomerId = dto.CustomerId,
            UserId = dto.UserId,
            InvoiceNumber = dto.InvoiceNumber,
            InvoiceDate = dto.InvoiceDate,
            TotalAmount = totalAmount,
            RecordDate = DateTime.UtcNow,
            Lines = invoiceLines
        };

        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync(cancellationToken);

        return invoice.InvoiceId;
    }
}