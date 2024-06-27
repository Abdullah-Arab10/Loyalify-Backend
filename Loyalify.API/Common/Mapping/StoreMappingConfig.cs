using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Services.CategoryServices.Commands.AddCategory;
using Loyalify.Application.Services.CategoryServices.Queries.GetCategories;
using Loyalify.Application.Services.StoreServices.Queries.DeactivateStore;
using Loyalify.Application.Services.StoreServices.Queries.SeeStoresList;
using Loyalify.Contracts.Category;
using Loyalify.Contracts.Store;
using Loyalify.Domain.Entities;
using Mapster;

namespace Loyalify.API.Common.Mapping;

public class StoreMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SeeStoresListResult, SeeStoresListResponse>()
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Stores, src => src.Stores.Adapt<List<StoresListDTO>>());
        config.NewConfig<GetCategoriesResult, GetCategoriesResponse>()
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.Categories, src => src.Categories.Adapt<List<StoreCategory>>());
        config.NewConfig<AddCategoryRequest, AddCategoryCommand>();
        config.NewConfig<AddCategoryResult, AddCategoryResponse>();
        config.NewConfig<DeactivateStoreResult, DeactivateStoreCommand>();
    }
}
