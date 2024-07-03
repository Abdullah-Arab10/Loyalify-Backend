using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.Store.Commands.AddStore;

public record AddStoreCommand(
    string Name,
    string Description,
    string Address,
    string PhoneNumber,
    decimal PointRation,
    string Email,
    string Password,
    int CategoryId,
    string CoverImage,
    string StoreImage) : IRequest<ErrorOr<AddStoreResult>>;
