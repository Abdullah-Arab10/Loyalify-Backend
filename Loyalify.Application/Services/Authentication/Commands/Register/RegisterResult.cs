using System.Net;

namespace Loyalify.Application.Services.Authentication.Commands.Register;

public record RegisterResult(
    HttpStatusCode StatusCode,
    string Message);
