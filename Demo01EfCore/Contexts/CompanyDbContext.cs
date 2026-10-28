

using Demo01EfCore.Configurations;
using Demo01EfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)   
        {
            #region Non-Clean Way
            // modelBuilder.Entity<Employee>().ToTable("EmployeesTable");

            // //modelBuilder.Entity<Employee>().HasKey("EmpId");  // not a safe Version

            // //  modelBuilder.Entity<Employee>().HasKey(nameof(Employee.EmpId));

            // modelBuilder.Entity<Employee>().HasKey(E => E.EmpId);  //more safe  Identity(1,1)

            // modelBuilder.Entity<Employee>().Property(E => E.EmpId)
            //     .UseIdentityColumn(10, 10);

            //// modelBuilder.Entity<Employee>().Property("Name");  //throw ex

            //// modelBuilder.Entity<Employee>().Property<string>("Name");  //property not existed property : generic  :shadow Property
            // // Ef Core will Create Column in table employee Name :nvarchar(max) and not existed In class


            // modelBuilder.Entity<Employee>().Property(E => E.EmpName)
            //     .HasColumnName("EmployeeName")
            //     .HasColumnType("varchar")
            //     .HasMaxLength(50)
            //     .IsRequired(true);

            // modelBuilder.Entity<Employee>()
            //     .Property(E => E.Salary)

            //    // .HasColumnType("decimal(10,3)");
            //    .HasPrecision(10, 3);


            // modelBuilder.Entity<Employee>()
            //     .ToTable(t => t.HasCheckConstraint("CheckAgeConstraint", "Age between 22 and 40"));


            // modelBuilder.Entity<Employee>()
            //     .Property(E => E.Email)
            //     .IsRequired();


            // modelBuilder.Entity<Employee>()
            //     .ToTable(t => t.HasCheckConstraint("EmailFormatConstraint", "Email like '%@%.%'"));  //Khaled@gmail.com


            // modelBuilder.Entity<Employee>()
            //     .Ignore(E => E.UserName);


            // modelBuilder.Entity<Employee>()
            //     .Property<DateTime>("CreatedAt")
            //     .HasDefaultValueSql("GETDATE()"); 
            #endregion


            //modelBuilder.ApplyConfiguration(new EmployeeConfigurations());
            //modelBuilder.ApplyConfiguration(new DepartmentConfigurations());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  //Reflection 

            #region Non-Clean Way
            //modelBuilder.Entity<Department>(D =>
            //   {
            //       D.ToTable("DepartmentsTable", "Sales");
            //       D.HasKey(D => D.DeptId);
            //       D.Property(D => D.DeptId)
            //       .UseIdentityColumn(10, 10);
            //       D.Property(D => D.DeptName)
            //       .HasColumnName("Department Name")
            //       .HasColumnType("varchar(50)")
            //       .IsRequired();


            //       D.Ignore(D => D.Serial);


            //       //D.Property(D => D.DateOfCreation)
            //       //.HasDefaultValue(DateTime.Now);
            //       //If No Manual value
            //       // will insert in this column In Database Time of migration
            //       // if update happen never Change unless you change it manual



            //       D.Property(D => D.DateOfCreation)
            //    .HasDefaultValueSql("GETDATE()");  //CreatedAt
            //                                       // If No manual value inserted from App
            //                                       //Call GETDATE() , Calculate CURRENT Time of sql server and inserted as a value
            //                                       // IF uPDATE hAPPEN Never Change value Unless You Change it manual


            //       //   D.Property(D => D.DateOfCreation)
            //       //.HasComputedColumnSql("GETDATE()");  //ModifiedAt
            //       //No Manual value is allowed
            //       // Call GETDATE() , Calculate Current time of swl server and inserted as a value
            //       // If Update Happen , Recalculate GETDATE() ,Call GETDATE() again and again

            #endregion'


              




        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}
