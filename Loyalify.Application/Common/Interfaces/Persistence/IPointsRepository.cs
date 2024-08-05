using Loyalify.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalify.Application.Common.Interfaces.Persistence;

public interface IPointsRepository
{
   Task<decimal> GetUserPoints(Guid userId);
}
