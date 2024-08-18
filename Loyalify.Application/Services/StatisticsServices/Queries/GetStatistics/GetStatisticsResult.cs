using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetStatistics;

public record GetStatisticsResult(HttpStatusCode Status, object Items );

