using CarWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Presistance
{
    public class CarWorkshopDbContext : DbContext
    {
        public CarWorkshopDbContext(DbContextOptions<CarWorkshopDbContext> options) : base(options) { }

        public DbSet<Domain.Entities.CarWorkshop> CarWorkshops { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarWorkshopDb;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.CarWorkshop>(
                options => options.OwnsOne(c => c.ContactDetails));
        }
    }
}
