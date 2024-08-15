using System.Net;

namespace Loyalify.Application.Services.Authentication.Commands.RegisterACashier;

public record RegisterACashierResult(
    HttpStatusCode Status,
    string Message);
