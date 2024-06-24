using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Common.Errors;
using Loyalify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.Store.Commands.AddStore;

public class AddStoreCommandHandler(
    IUserRepository userRepository,
    IStoreRepository storeRepository) :
    IRequestHandler<AddStoreCommand, ErrorOr<AddStoreResult>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IStoreRepository _storeRepository = storeRepository;
    public async Task<ErrorOr<AddStoreResult>> Handle(AddStoreCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        var category = await _storeRepository.GetCategory(command.Category);
        if(category is null)
        {
            return Errors.Category.CategoryNotExisted;
        }
        var storeManager = new User()
        {
            FirstName = command.Email,
            LastName = command.Email,
            Email = command.Email,
            UserName = command.Email,
            PhoneNumber = command.PhoneNumber,
            Address = command.Address,
        };
        await _userRepository.Add(storeManager, command.Password);
        await _userRepository.AddUserToRole(storeManager, "StoreManager");
        var store = new Domain.Entities.Store()
        {
            Name = command.Name,
            Description = command.Description,
            Address = command.Address,
            PhoneNumber = command.PhoneNumber,
            User = storeManager,
            Category = category,
            CoverImage = command.CoverImage,
            StoreImage = command.StoreImage
        };
        await _storeRepository.Add(store);
        return new AddStoreResult(
            (HttpStatusCode)StatusCodes.Status201Created,
            Message: "Store and store manager account have been created Successfully");
    }
}
