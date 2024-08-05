using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Loyalify.Infrastructure.Persistence;

    public class PointsRepository(LoyalifyDbContext dbContext) : IPointsRepository
    {

    private readonly LoyalifyDbContext _dbContext = dbContext;



    public async Task<decimal> GetUserPoints(Guid userId)
    {
      
            decimal points = await _dbContext.Users.Where(x => x.Id == userId).Select(x => x.Points).FirstOrDefaultAsync();
            return points;
       

    }



   
}

