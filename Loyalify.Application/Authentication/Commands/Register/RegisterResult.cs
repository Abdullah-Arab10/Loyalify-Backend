using System.Net;

namespace Loyalify.Application.Authentication.Commands.Register;

public record RegisterResult(
    HttpStatusCode StatusCode);
