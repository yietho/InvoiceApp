using InvoiceApp.Application.Common.Interfaces;
using InvoiceApp.Application.Features.Auth.Dto;
using InvoiceApp.Domain.Entitites;
using InvoiceApp.Domain.Interfaces;
using MediatR;


namespace InvoiceApp.Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<Unit>
{
    public UserRegisterDto User { get; set; } = default!;
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByUserNameAsync(request.User.UserName);
        if (existingUser is not null)
            throw new InvalidOperationException($"User with username '{request.User.UserName}' already exists.");

        var hashedPassword = _passwordHasher.HashPassword(request.User.Password);
        var user = new User
        {
            UserName = request.User.UserName,
            PasswordHash = hashedPassword,
            RecordDate = DateTime.UtcNow
        };

        await _userRepository.AddAsync(user);
        return Unit.Value;
    }
}