using FluentValidation;
using InvoiceApp.Application.Features.Invoices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Invoices.Commands.UpdateInvoice;

public class UpdateInvoiceLineValidator : AbstractValidator<UpdateInvoiceLineDto>
{
    public UpdateInvoiceLineValidator()
    {
        RuleFor(x => x.ItemName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Quentity).GreaterThan(0);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}