using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Common.Errors;
using Loyalify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.Authentication.Commands.Register;

public class RegisterCommandHandler
    (IUserRepository userRepository) :
    IRequestHandler<RegisterCommand, ErrorOr<RegisterResult>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<ErrorOr<RegisterResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Validate the user doesn't exist 
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        // Create user & persist to DB
        var user = new User()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            PhoneNumber = command.PhoneNumber,
            UserName = command.Email,
            Address = command.Address,
            IsActive = true
        };
        var isCreated = await _userRepository.Add(user, command.Password);
        var errors = new List<string>();
        foreach (var error in isCreated.Errors)
        {
            errors.Add(error.Description);
        }

        if (!isCreated.Succeeded)
        {
            return Errors.Validation.IdentityError(errors);
        }
        var result = await _userRepository.AddUserToRole(user, "User");
        if (!result.Succeeded)
        {
            return new Error();
        }
        return new RegisterResult(
            (HttpStatusCode)StatusCodes.Status201Created,
            Message: "Registered successfully");
    }
}
