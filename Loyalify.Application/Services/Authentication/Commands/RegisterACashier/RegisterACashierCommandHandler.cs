using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Common.Errors;
using Loyalify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;
namespace Loyalify.Application.Services.Authentication.Commands.RegisterACashier;

public class RegisterACashierCommandHandler(
    IUserRepository userRepository,
    IStoreRepository storeRepository) :
    IRequestHandler<RegisterACashierCommand, ErrorOr<RegisterACashierResult>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IStoreRepository _storeRepository = storeRepository;
    public async Task<ErrorOr<RegisterACashierResult>> Handle(RegisterACashierCommand command, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        var storeManager = await _userRepository.GetUserById(command.StoreManagerId);
        var storeId = await _storeRepository.GetUserStoreId(command.StoreManagerId);
        var store = await _storeRepository.GetStoreById(storeId);
        var user = new User()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            UserName = command.Email,
            Store = store,
            Address = storeManager!.Address,
            PhoneNumber = storeManager!.PhoneNumber,
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
        var result = await _userRepository.AddUserToRole(user, "Cashier");
        if (!result.Succeeded)
        {
            return new Error();
        }
        return new RegisterACashierResult(
            (HttpStatusCode)StatusCodes.Status201Created,
            Message: "Cashier registered successfully");
    }
}
