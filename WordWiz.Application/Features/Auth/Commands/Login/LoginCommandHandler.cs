using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WordWiz.Application.Common.Exceptions;
using WordWiz.Application.Common.Settings;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IRepository<User> _userRepository;
    private readonly JwtSettings _jwtSettings;

    public LoginCommandHandler(IRepository<User> userRepository, IOptions<JwtSettings> jwtSettings)
    {
        _userRepository = userRepository;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();
        var user = users.FirstOrDefault(u => u.Username == request.Username);

        if (user == null || !VerifyPassword(request.Password, user.PasswordHash))
            throw new CustomException("Invalid username or password");

        return GenerateJwtToken(user);
    }

    private bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }

    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
} 