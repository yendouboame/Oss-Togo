using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolidarityFund.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidarityFund.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Priest> Priests { get; set; }
        public DbSet<Diocese> Dioceses { get; set; }
        public DbSet<Pension> Pensions { get; set; }
        public DbSet<Contribution> Contributions { get; set; }
    }
}
