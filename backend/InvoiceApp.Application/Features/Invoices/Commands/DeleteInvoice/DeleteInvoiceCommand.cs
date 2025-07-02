using InvoiceApp.Application.Common.Interfaces;
using InvoiceApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Invoices.Commands.DeleteInvoice;

public class DeleteInvoiceCommand : IRequest<Unit>
{
    public int InvoiceId { get; set; }

    public DeleteInvoiceCommand(int invoiceId)
    {
        InvoiceId = invoiceId;
    }
}

public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, Unit>
{
    private readonly IAppDbContext _context;

    public DeleteInvoiceCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = await _context.Invoices
            .Include(i => i.Lines)
            .FirstOrDefaultAsync(x => x.InvoiceId == request.InvoiceId, cancellationToken);

        if (invoice == null)
            throw new Exception("Invoice not found");

        _context.InvoiceLines.RemoveRange(invoice.Lines);
        _context.Invoices.Remove(invoice);

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}