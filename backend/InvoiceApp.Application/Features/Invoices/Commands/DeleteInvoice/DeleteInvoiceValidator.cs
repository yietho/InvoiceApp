using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Invoices.Commands.DeleteInvoice;

public class DeleteInvoiceValidator : AbstractValidator<DeleteInvoiceCommand>
{
    public DeleteInvoiceValidator()
    {
        RuleFor(x => x.InvoiceId).GreaterThan(0);
    }
}