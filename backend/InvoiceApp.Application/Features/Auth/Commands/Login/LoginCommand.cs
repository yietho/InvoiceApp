using InvoiceApp.Application.Common.Interfaces;
using InvoiceApp.Application.Features.Auth.Dto;
using InvoiceApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<string>
{
    public UserLoginDto User { get; set; } = default!;
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetWithCustomerByUserNameAsync(request.User.UserName);

        if (user == null)
            throw new UnauthorizedAccessException("Invalid credentials");

        var isPasswordValid = user.IsPlainPassword // Seed userlar için şifre karşılaştırma gösterim amaçlı prod için uygun değildir.
            ? request.User.Password == user.PasswordHash 
            : _passwordHasher.VerifyPassword(request.User.Password, user.PasswordHash);

        if (!isPasswordValid)
            throw new UnauthorizedAccessException("Invalid credentials");

        return _tokenService.GenerateToken(user);
    }
}