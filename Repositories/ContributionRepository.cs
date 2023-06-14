using Microsoft.EntityFrameworkCore;
using SolidarityFund.Data;
using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Repositories
{
    public class ContributionRepository
    {
        private readonly ApplicationDbContext _context;

        public ContributionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Contribution> GetAll()
        {
            return _context.Contributions
                .Include(c => c.Priest)
                .Where(c => !c.IsDeleted)
                .OrderByDescending(c => c.Date)
                .ToList();
        }

        public void Add(Contribution contribution)
        {
            if (!Exists(contribution))
            {
                _context.Contributions.Add(contribution);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Cette cotisation a déjà été enregistrée");
            }
        }

        private bool Exists(Contribution contribution)
        {
            return _context.Contributions
                .Any(c => !c.IsDeleted && c.PriestId == contribution.PriestId
                 && c.Date == contribution.Date && c.Ammount == contribution.Ammount);
        }
    }
}
