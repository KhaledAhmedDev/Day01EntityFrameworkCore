using Demo01EfCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Demo01EfCore.Configurations
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("EmployeesTable");

            //builder.HasKey("EmpId");  // not a safe Version

            //  builder.HasKey(nameof(Employee.EmpId));

            builder.HasKey(E => E.EmpId);  //more safe  Identity(1,1)

            builder.Property(E => E.EmpId)
                .UseIdentityColumn(10, 10);

            // builder.Property("Name");  //throw ex

            // builder.Property<string>("Name");  //property not existed property : generic  :shadow Property
            // Ef Core will Create Column in table employee Name :nvarchar(max) and not existed In class


            builder.Property(E => E.EmpName)
                .HasColumnName("EmployeeName")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired(true);

            builder
                .Property(E => E.Salary)

               // .HasColumnType("decimal(10,3)");
               .HasPrecision(10, 3);


            builder
                .ToTable(t => t.HasCheckConstraint("CheckAgeConstraint", "Age between 22 and 40"));


            builder
                .Property(E => E.Email)
                .IsRequired();


            builder
                .ToTable(t => t.HasCheckConstraint("EmailFormatConstraint", "Email like '%@%.%'"));  //Khaled@gmail.com


            builder
                .Ignore(E => E.UserName);


            builder
                .Property<DateTime>("CreatedAt")
                .HasDefaultValueSql("GETDATE()");


            //builder.HasOne<Department>()
            //    .WithOne()
            //    .HasForeignKey<Department>(D => D.DeptManagerId)
            //    .OnDelete(DeleteBehavior.Restrict);


            //its properties are stored as columns In Employee table
            builder.ComplexProperty(E => E.EmpAddress, address =>
            {
                address.Property(a => a.City)
                .HasColumnName("EmployeeCity");
                

                address.Property(a => a.Street)
                .HasColumnName("EmployeeStreet");
                address.Property(a => a.Country)
                .HasColumnName("EmployeeCountry");



            });  // Ef Core 8 : owned relationship
        }
    }
}
