using Microsoft.EntityFrameworkCore;
using SolidarityFund.Data;
using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Repositories
{
    public class DioceseRepository
    {
        private readonly ApplicationDbContext _context;

        public DioceseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Diocese> GetAll()
        {
            return _context.Dioceses
                .Include(d => d.Priests)
                .Where(d => !d.IsDeleted)
                .OrderBy(d => d.Name)
                .ToList();
        }

        public void Create(Diocese diocese)
        {
            _context.Dioceses.Add(diocese);
            _context.SaveChanges();
        }

        public Diocese Details(int dioceseId)
        {
            return _context.Dioceses
                .Include(d => d.Priests)
                .FirstOrDefault(d => d.Id == dioceseId);
        }
    }
}
