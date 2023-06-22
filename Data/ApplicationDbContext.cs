using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolidarityFund.Models.Entities;

namespace SolidarityFund.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cost> Costs { get; set; }
        public DbSet<Priest> Priests { get; set; }
        public DbSet<Diocese> Dioceses { get; set; }
        public DbSet<Pension> Pensions { get; set; }
        public DbSet<Contribution> Contributions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Diocese>().HasData(
                new Diocese { Id = 1, Name = "Diocèse de Dapaong" },
                new Diocese { Id = 2, Name = "Diocèse de Kara" },
                new Diocese { Id = 3, Name = "Diocèse de Sokodé" },
                new Diocese { Id = 4, Name = "Diocèse d'Atakpamé" },
                new Diocese { Id = 5, Name = "Diocèse de Kpalimé" },
                new Diocese { Id = 6, Name = "Diocèse de Lomé" },
                new Diocese { Id = 7, Name = "Diocèse d'Aného" });
        }
    }
}
