using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Services.StatisticsServices.Queries.GetStatistics;
using Loyalify.Contracts.Statistics;
using Mapster;

namespace Loyalify.API.Common.Mapping;

public class StatisticsMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetStatisticsResult, GetStatisticsResponse>()
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.items, src => src.Items.Adapt<GetStatisticsDTO>());
    }
}
