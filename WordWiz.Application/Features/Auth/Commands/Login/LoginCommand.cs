using MediatR;

namespace WordWiz.Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<string> // returns JWT token
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
} 