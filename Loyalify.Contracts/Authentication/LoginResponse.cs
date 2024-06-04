using System.Net;

namespace Loyalify.Contracts.Authentication;

public class LoginResponse
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    public string Token { get; set; } = null!;
}
