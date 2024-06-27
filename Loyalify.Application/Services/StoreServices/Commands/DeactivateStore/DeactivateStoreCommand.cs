using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.StoreServices.Queries.DeactivateStore;

public record DeactivateStoreCommand(int Id): IRequest<ErrorOr<DeactivateStoreResult>>;
