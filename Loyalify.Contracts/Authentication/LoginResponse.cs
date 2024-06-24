using System.Net;

namespace Loyalify.Contracts.Authentication;

public class LoginResponse
{
    public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;
    public string Token { get; set; } = null!;
}
