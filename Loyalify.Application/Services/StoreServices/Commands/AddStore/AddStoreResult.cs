using System.Net;

namespace Loyalify.Application.Services.Store.Commands.AddStore;

public record AddStoreResult(
    HttpStatusCode Status,
    string Message);