using System.Net;

namespace Loyalify.Application.Services.StoreServices.Commands.UpdateStore;

public record UpdateStoreResult(
    HttpStatusCode Status,
    string Message);
