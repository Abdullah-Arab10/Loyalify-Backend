using System.Net;

namespace Loyalify.Application.Services.Authentication.Commands.Register;

public record RegisterResult(
    HttpStatusCode Status,
    string Message);
