using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Invoices.Commands.CreateInvoice;

public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceCommand>
{
    public CreateInvoiceValidator()
    {
        RuleFor(x => x.Invoice.CustomerId)
            .GreaterThan(0).WithMessage("CustomerId must be greater than 0");

        RuleFor(x => x.Invoice.UserId)
            .GreaterThan(0).WithMessage("UserId must be greater than 0");

        RuleFor(x => x.Invoice.InvoiceNumber)
            .NotEmpty().WithMessage("Invoice number is required")
            .MaximumLength(50).WithMessage("Invoice number must not exceed 50 characters");

        RuleFor(x => x.Invoice.InvoiceDate)
            .NotEmpty().WithMessage("Invoice date is required");

        RuleFor(x => x.Invoice.Lines)
            .NotEmpty().WithMessage("At least one invoice line is required");

        RuleForEach(x => x.Invoice.Lines).SetValidator(new CreateInvoiceLineValidator());
    }
}