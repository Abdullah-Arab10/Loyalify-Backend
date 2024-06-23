using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Loyalify.Application.Services.Store.Commands.AddStore;

public record AddStoreCommand(
    string Name,
    string Description,
    string Address,
    string PhoneNumber,
    string Email,
    string Password,
    string CoverImage,
    string StoreImage) : IRequest<ErrorOr<AddStoreResult>>;
