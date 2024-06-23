using Loyalify.Application.Services.Store.Commands.AddStore;
using Loyalify.Contracts.Store;
using Mapster;

namespace Loyalify.API.Common.Mapping;

public class StoreMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        /*config.NewConfig<AddStoreRequest, AddStoreCommand>()
           .Map(dest => dest.CoverImageFile, src => src.CoverImageFile)
           .Map(dest => dest.StoreImageFile, src => src.StoreImageFile);
        config.NewConfig<AddStoreResult, AddStoreResponse>();*/
    }
}
