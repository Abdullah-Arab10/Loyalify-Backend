using Loyalify.Application.Common.DTOs;
using System.Net;

namespace Loyalify.Application.Services.StoreServices.Queries.GetStoreInfo;

public record GetStoreInfoResult(HttpStatusCode Status,GetStoreInfoDTO Store);

