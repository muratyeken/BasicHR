using HumanResourcesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Infrastructure.Context
{
    public class HRDbContext:DbContext
    {
        public HRDbContext(DbContextOptions<HRDbContext>options):base(options)
        {

        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Company> Companies { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
