using Microsoft.EntityFrameworkCore;
using SolidarityFund.Data;
using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Repositories
{
    public class PriestRepository
    {
        private readonly ApplicationDbContext _context;

        public PriestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Priest> GetAll()
        {
            return _context.Priests
                .Include(p => p.Diocese)
                .Where(p => !p.IsDeleted)
                .ToList();
        }

        public void Create(Priest priest)
        {
            _context.Priests.Add(priest);
            _context.SaveChanges();
        }

        public Priest Details(int priestId)
        {
            return _context.Priests
                .FirstOrDefault(p => p.Id == priestId);
        }

        public void Edit(Priest priest)
        {
            var old = _context.Priests.Find(priest.Id);

            old.LastName = priest.LastName;
            old.FirstName = priest.FirstName;
            old.DateOfBirth = priest.DateOfBirth;
            old.OrdinationDate = priest.OrdinationDate;
            old.DioceseId = priest.DioceseId;

            _context.SaveChanges();
        }

        public void Delete(int priestId)
        {
            var priest = _context.Priests.Find(priestId);

            priest.IsDeleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<Priest> GetEligiblePriests()
        {
            var allPriests = GetAll();
            var eligiblePriests = new List<Priest>();

            foreach (var priest in allPriests)
            {
                int age = CalculateAge(priest.DateOfBirth);

                if (age < 70 && DateTime.Now >= priest.OrdinationDate.AddMonths(1))
                {
                    eligiblePriests.Add(priest);
                }
                else if (age == 70 && DateTime.Now < priest.DateOfBirth.AddYears(70).AddMonths(1))
                {
                    eligiblePriests.Add(priest);
                }
            }

            return eligiblePriests;
        }

        private int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;

            if (DateTime.Now < birthDate.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
