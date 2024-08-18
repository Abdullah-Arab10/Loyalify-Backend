using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Common.Errors;
using Loyalify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.NotificationServices.Commands.AddDeviceToken;

public class AddDeviceTokenCommandHandler(
    IUserRepository userRepository) :
    IRequestHandler<AddDeviceTokenCommand, ErrorOr<AddDeviceTokenResult>>
{
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<ErrorOr<AddDeviceTokenResult>> Handle(AddDeviceTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.Id);
        if (user == null)
        {
            return Errors.User.NoUser;
        }
        var token = new NotificationToken()
        {
            User = user,
            DeviceToken = request.DeviceToken
        };
        _userRepository.AddDeviceToken(token);
        return new AddDeviceTokenResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            "Device token has been added to the user");
    }
}
