using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Services.CategoryServices.Commands.AddCategory;
using Loyalify.Application.Services.CategoryServices.Queries.GetCategories;
using Loyalify.Application.Services.StatisticsServices.Queries.GetActiveStoresCount;
using Loyalify.Application.Services.StatisticsServices.Queries.GetStoresCount;
using Loyalify.Application.Services.StoreServices.Queries.DeactivateStore;
using Loyalify.Application.Services.StoreServices.Queries.GetAllStoresAdmin;
using Loyalify.Application.Services.StoreServices.Queries.GetAllStoresUser;
using Loyalify.Application.Services.StoreServices.Queries.GetPopularStores;
using Loyalify.Application.Services.StoreServices.Queries.GetStoreInfo;
using Loyalify.Contracts.Category;
using Loyalify.Contracts.Statistics;
using Loyalify.Contracts.Store;
using Loyalify.Domain.Entities;
using Mapster;

namespace Loyalify.API.Common.Mapping;

public class StoreMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllStoresUserResult, SeeStoresListResponse>()
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Items, src => src.Items.Adapt<List<StoresListUserDTO>>());
        config.NewConfig<GetAllStoresAdminResult, SeeStoresListResponse>()
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Items, src => src.Items.Adapt<List<StoresListAdminDTO>>());
        config.NewConfig<SeeStoresListRequest, GetAllStoresAdminQuery>();
        config.NewConfig<SeeStoresListRequest, GetAllStoresUserQuery>();
        config.NewConfig<GetCategoriesResult, GetCategoriesResponse>()
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.Items, src => src.Items.Adapt<List<StoreCategory>>());
        config.NewConfig<AddCategoryRequest, AddCategoryCommand>();
        config.NewConfig<AddCategoryResult, AddCategoryResponse>();
        config.NewConfig<DeactivateStoreResult, DeactivateStoreResponse>();
        config.NewConfig<DeactivateStoreRequest, DeactivateStoreCommand>();
        config.NewConfig<GetStoreInfoResult, GetStoreInfoResponse>()
          .Map(dest => dest.Status, src => src.Status)
          .Map(dest => dest.Items, src => src.Items.Adapt<GetStoreInfoDTO>());
        config.NewConfig<GetPopularStoresResult, SeeStoresListResponse>()
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Items, src => src.Items.Adapt<List<StoresListUserDTO>>());
    }
}
