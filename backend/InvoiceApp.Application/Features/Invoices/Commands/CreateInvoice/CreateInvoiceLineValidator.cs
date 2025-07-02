using FluentValidation;
using InvoiceApp.Application.Features.Invoices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Invoices.Commands.CreateInvoice;

public class CreateInvoiceLineValidator : AbstractValidator<CreateInvoiceLineDto>
{
    public CreateInvoiceLineValidator()
    {
        RuleFor(x => x.ItemName)
            .NotEmpty().WithMessage("Item name is required");

        RuleFor(x => x.Quentity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("UserId is required");
    }
}