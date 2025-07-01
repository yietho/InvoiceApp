using InvoiceApp.Application.Common.Interfaces;
using InvoiceApp.Application.Features.Invoices.Dtos;
using InvoiceApp.Domain.Entitites;
using InvoiceApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Invoices.Commands.UpdateInvoice;

public class UpdateInvoiceCommand : IRequest<Unit>
{
    public UpdateInvoiceDto Invoice { get; set; }

    public UpdateInvoiceCommand(UpdateInvoiceDto invoice)
    {
        Invoice = invoice;
    }
}

public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, Unit>
{
    private readonly IAppDbContext _context;

    public UpdateInvoiceCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Invoice;

        var invoice = await _context.Invoices
            .Include(i => i.Lines)
            .FirstOrDefaultAsync(i => i.InvoiceId == dto.InvoiceId, cancellationToken);

        if (invoice == null)
            throw new Exception("Invoice not found.");

        invoice.CustomerId = dto.CustomerId;
        invoice.UserId = dto.UserId;
        invoice.InvoiceNumber = dto.InvoiceNumber;
        invoice.InvoiceDate = dto.InvoiceDate;
        invoice.RecordDate = DateTime.UtcNow;

        _context.InvoiceLines.RemoveRange(invoice.Lines);
        invoice.Lines = dto.Lines.Select(x => new InvoiceLine
        {
            ItemName = x.ItemName,
            Quentity = x.Quentity,
            Price = x.Price,
            UserId = x.UserId,
            RecordDate = DateTime.UtcNow
        }).ToList();

        invoice.TotalAmount = invoice.Lines.Sum(x => x.Price * x.Quentity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}