using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.PointsServices.Commands.AddPoints;

public record AddPointsCommand(
    Guid UserId,
    Guid CashierId,
    decimal Bill): IRequest<ErrorOr<AddPointsResult>>;
