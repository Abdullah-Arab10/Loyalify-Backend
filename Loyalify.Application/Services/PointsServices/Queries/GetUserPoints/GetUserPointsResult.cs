using Loyalify.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Loyalify.Application.Services.PointsServices.Queries.GetUserPoints;

public record GetUserPointsResult(
    HttpStatusCode Status,
    decimal points);


