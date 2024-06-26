using Loyalify.Application.Common.DTOs;
using System.Net;

namespace Loyalify.Application.Services.StoreServices.Queries.SeeStoresList;

public record SeeStoresListResult(
    HttpStatusCode Status,
    List<StoresListDTO> Stores);
