using Loyalify.Application.Services.Authentication.Commands.Register;
using Loyalify.Application.Services.Authentication.Queries.Login;
using Loyalify.Contracts.Authentication;
using Mapster;

namespace Loyalify.API.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<RegisterResult, RegisterResponse>();
        config.NewConfig<LoginResult, LoginResponse>();
    }
}
