using System.Net;

namespace Loyalify.Application.Services.StoreServices.Queries.DeactivateStore;

public record DeactivateStoreResult(
    HttpStatusCode Status,
    string Message);
