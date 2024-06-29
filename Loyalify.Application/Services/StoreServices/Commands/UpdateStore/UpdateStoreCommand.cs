using ErrorOr;
using Loyalify.Application.Common.DTOs;
using MediatR;

namespace Loyalify.Application.Services.StoreServices.Commands.UpdateStore;

public record UpdateStoreCommand(
    UpdateStoreDTO Store,
    int Id) : IRequest<ErrorOr<UpdateStoreResult>>;
