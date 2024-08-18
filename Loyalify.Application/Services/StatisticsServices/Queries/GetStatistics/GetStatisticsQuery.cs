using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetStatistics;

public record GetStatisticsQuery():IRequest<ErrorOr<GetStatisticsResult>>;

