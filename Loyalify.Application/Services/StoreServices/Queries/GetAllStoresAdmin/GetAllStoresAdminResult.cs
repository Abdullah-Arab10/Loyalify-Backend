using Loyalify.Application.Common.DTOs;
using System.Net;

namespace Loyalify.Application.Services.StoreServices.Queries.GetAllStoresAdmin;

public record GetAllStoresAdminResult(
    HttpStatusCode Status,
    List<StoresListAdminDTO> Stores);
