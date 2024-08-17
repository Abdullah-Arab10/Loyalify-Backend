using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Services.OfferServices.Queries.GetAllOffersUser;
using Loyalify.Application.Services.OfferServices.Queries.GetPopularOffers;
using Loyalify.Application.Services.OfferServices.Queries.GetStoreOffers;
using Loyalify.Application.Services.StatisticsServices.Queries.GetTotalPointsUsed;
using Loyalify.Application.Services.StoreServices.Queries.GetStoreInfo;
using Loyalify.Contracts.Offer;
using Loyalify.Contracts.Statistics;
using Loyalify.Contracts.Store;
using Mapster;

namespace Loyalify.API.Common.Mapping;

public class OfferMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllOffersUserResult, GetAllOffersResponse>()
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Items, src => src.Items.Adapt<List<OffersListUserDTO>>());
        config.NewConfig<GetStoreOffersResult, GetAllOffersResponse>()
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Items, src => src.Items.Adapt<List<OffersListUserDTO>>());
        config.NewConfig<GetStoreInfoResult, GetStoreInfoResponse>()
          .Map(dest => dest.Status, src => src.Status)
          .Map(dest => dest.Items, src => src.Items.Adapt<OfferDetailsDTO>());
        config.NewConfig<GetPopularOffersResult, GetAllOffersResponse>()
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Items, src => src.Items.Adapt<List<OffersListUserDTO>>());
    }
}
