using FluentValidation;
using InvoiceApp.Application.Features.Invoices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Invoices.Commands.UpdateInvoice;

public class UpdateInvoiceValidator : AbstractValidator<UpdateInvoiceDto>
{
    public UpdateInvoiceValidator()
    {
        RuleFor(x => x.InvoiceId).GreaterThan(0);
        RuleFor(x => x.CustomerId).GreaterThan(0);
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.InvoiceNumber).NotEmpty().MaximumLength(100);
        RuleFor(x => x.InvoiceDate).NotEmpty();
        RuleFor(x => x.Lines)
            .NotEmpty().WithMessage("Invoice must have at least one line item.");

        RuleForEach(x => x.Lines).SetValidator(new UpdateInvoiceLineValidator());
    }
}

