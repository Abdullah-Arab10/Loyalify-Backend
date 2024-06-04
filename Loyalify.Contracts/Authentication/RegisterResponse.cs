using System.Net;

namespace Loyalify.Contracts.Authentication;

public class RegisterResponse
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Created;
}
