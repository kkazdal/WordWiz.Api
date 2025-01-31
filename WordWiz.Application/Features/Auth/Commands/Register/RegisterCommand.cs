using MediatR;

namespace WordWiz.Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<long>
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
} 