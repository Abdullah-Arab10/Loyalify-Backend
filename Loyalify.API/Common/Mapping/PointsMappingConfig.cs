using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Services.PointsServices.Queries.GetUserPoints;
using Loyalify.Contracts.Points;
using Mapster;

namespace Loyalify.API.Common.Mapping;

public class PointsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetUserPointsResult, GetUserPointsResponse>()
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Points, src => src.points);
    
    }
}
