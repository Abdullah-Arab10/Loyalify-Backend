using ErrorOr;
using Loyalify.Domain.Entities;
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
    string Category,
    string CoverImage,
    string StoreImage) : IRequest<ErrorOr<AddStoreResult>>;
