using MediatR;
using WordWiz.Application.Common.Exceptions;
using WordWiz.Application.Interfaces.Repositories;
using WordWiz.Domain.Entities;

namespace WordWiz.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, long>
{
    private readonly IRepository<User> _userRepository;

    public RegisterCommandHandler(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<long> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();
        
        if (users.Any(u => u.Username == request.Username))
            throw new CustomException("Username is already taken");
        
        if (users.Any(u => u.Email == request.Email))
            throw new CustomException("Email is already registered");

        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = "User" // Yeni kayıt olan kullanıcılar varsayılan olarak User rolünde
        };

        var result = await _userRepository.AddAsync(user);
        return result.Id;
    }
} 