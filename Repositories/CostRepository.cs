using SolidarityFund.Data;
using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Repositories
{
    public class CostRepository
    {
        private readonly ApplicationDbContext _context;

        public CostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Cost GetCosts()
        {
            return _context.Costs.FirstOrDefault();
        }

        public void UpdateCosts(Cost cost)
        {
            var existingCost = _context.Costs.FirstOrDefault(c => c.Id == cost.Id);

            if (existingCost != null)
            {
                existingCost.Pension = cost.Pension;
                existingCost.Contribution = cost.Contribution;
            }
            else
            {
                _context.Costs.Add(cost);
            }

            _context.SaveChanges();
        }
    }
}
