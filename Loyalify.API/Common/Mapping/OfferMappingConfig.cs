using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Services.OfferServices.Queries.GetAllOffersUser;
using Loyalify.Application.Services.StoreServices.Queries.GetAllStoresUser;
using Loyalify.Contracts.Offer;
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

    }
}
