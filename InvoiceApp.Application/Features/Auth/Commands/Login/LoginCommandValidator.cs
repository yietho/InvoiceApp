using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Auth.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.User.UserName)
            .NotEmpty().WithMessage("UserName is required.");

        RuleFor(x => x.User.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}