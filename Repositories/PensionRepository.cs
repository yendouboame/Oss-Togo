using Microsoft.EntityFrameworkCore;
using SolidarityFund.Data;
using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Repositories
{
    public class PensionRepository
    {
        private readonly ApplicationDbContext _context;

        public PensionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pension> GetAll()
        {
            return _context.Pensions
                .Include(p => p.Priest)
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.Date)
                .ToList();
        }

        public void New(Pension pension)
        {
            if (!Exists(pension))
            {
                _context.Pensions.Add(pension);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Cette pension a déjà été allouée");
            }
        }

        private bool Exists(Pension pension)
        {
            return _context.Pensions
                .Any(p => !p.IsDeleted && p.PriestId == pension.PriestId
                 && p.Date == pension.Date && p.Ammount == pension.Ammount);
        }
    }
}
