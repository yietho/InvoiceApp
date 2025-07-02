using InvoiceApp.Application.Common.Interfaces;
using InvoiceApp.Application.Features.Invoices.Dtos;
using InvoiceApp.Domain.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Invoices.Queries.GetInvoices;

public class GetInvoicesQuery : IRequest<List<InvoiceDto>>
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public GetInvoicesQuery(DateTime? startDate = null, DateTime? endDate = null)
    {
        StartDate = startDate;
        EndDate = endDate;
    }
}

public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, List<InvoiceDto>>
{
    private readonly IAppDbContext _context;

    public GetInvoicesQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<InvoiceDto>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Invoices
            .Include(i => i.Lines)
            .Include(i => i.Customer)
            .Include(i => i.User)
            .AsQueryable();

        if (request.StartDate.HasValue)
            query = query.Where(i => i.InvoiceDate >= request.StartDate.Value);

        if (request.EndDate.HasValue)
            query = query.Where(i => i.InvoiceDate <= request.EndDate.Value);

        var invoices = await query
            .OrderByDescending(i => i.InvoiceDate)
            .ToListAsync(cancellationToken);

        return invoices.Adapt<List<InvoiceDto>>();
    }
}