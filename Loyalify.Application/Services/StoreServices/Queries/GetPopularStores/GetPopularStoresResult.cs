using Loyalify.Application.Common.DTOs;
using System.Net;

namespace Loyalify.Application.Services.StoreServices.Queries.GetPopularStores;

public record GetPopularStoresResult(
    HttpStatusCode Status,
    List<StoresListUserDTO> Items);
