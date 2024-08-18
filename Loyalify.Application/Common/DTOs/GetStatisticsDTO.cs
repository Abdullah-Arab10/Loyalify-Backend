using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalify.Application.Common.DTOs;

public class GetStatisticsDTO
{
    public int? activeOffers { get; set; } 
    public int? activeStores { get; set; }
    public int? totalOffers { get;set; }
    public int? totalStores { get; set;}
    public int? userCount { get; set; }
    public decimal? averagePointAmount { get; set;}
    public decimal? takenOffersRatio { get; set; }
    public decimal? totalPointsUsed { get; set; }
    

}
