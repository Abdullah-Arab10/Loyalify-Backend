using Loyalify.Application.Common.DTOs;
using System.Net;

namespace Loyalify.Application.Services.StoreServices.Queries.GetAllStoresUser;

public record GetAllStoresUserResult(
    HttpStatusCode Status,
    List<StoresListUserDTO> Items);
