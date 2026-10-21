
using Demo01EfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01EfCore.Contexts
{
    internal class CompanyDbContext:DbContext
    {

        public CompanyDbContext():base()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=CompanyDb;Trusted_Connection=true;TrustServerCertificate=true");
            //optionsBuilder.UseSqlServer("DataSource=.;IntialCatlog=CompanyDb;Integrated_Security=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
