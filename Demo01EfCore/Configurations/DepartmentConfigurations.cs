
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
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> D)
        {

            
                D.ToTable("DepartmentsTable", "Sales");
                D.HasKey(D => D.DeptId);
                D.Property(D => D.DeptId)
                .UseIdentityColumn(10, 10);
                D.Property(D => D.DeptName)
                .HasColumnName("Department Name")
                .HasColumnType("varchar(50)")
                .IsRequired();


                D.Ignore(D => D.Serial);


                //D.Property(D => D.DateOfCreation)
                //.HasDefaultValue(DateTime.Now);
                //If No Manual value
                // will insert in this column In Database Time of migration
                // if update happen never Change unless you change it manual



                D.Property(D => D.DateOfCreation)
             .HasDefaultValueSql("GETDATE()");  //CreatedAt
                                                // If No manual value inserted from App
                                                //Call GETDATE() , Calculate CURRENT Time of sql server and inserted as a value
                                                // IF uPDATE hAPPEN Never Change value Unless You Change it manual


            //   D.Property(D => D.DateOfCreation)
            //.HasComputedColumnSql("GETDATE()");  //ModifiedAt
            //No Manual value is allowed
            // Call GETDATE() , Calculate Current time of swl server and inserted as a value
            // If Update Happen , Recalculate GETDATE() ,Call GETDATE() again and again



            //D.HasOne<Employee>()
            //    .WithOne()
            //    .HasForeignKey<Department>(D => D.DeptManagerId)
            //    .OnDelete(DeleteBehavior.Restrict);




            D.HasOne(D => D.Manager)
                .WithOne(E => E.ManagedDepartment)
                .HasForeignKey<Department>()
                .OnDelete(DeleteBehavior.Restrict);
                


            //1-Cascade
            //Default :Required Relationship 
            //Delete Parent  & its related Children will be deleted from Db
            // On Delete Cascade


            //2-Set Null
            //Delete Parent & its related children [Fk] =====> null
            //In Condition fk must allow Null In DB
            //On Delete Set Null

            //3-No Action
            //Set responsibility to Db to reject or prevent deletion of parent
            //DB reject delete children reference parent
            // On Delete No Action
            // No Action: احيانا لو انت بتبدأ تخترق القوانين العامو للديليت اللى هى مش منطقية
            // 95%:send request in Db : DATABASE TOTALLY PREVENT FROM APP

            // 4 -Client Cascade
            // Ef Core will delete in Memory [Ram] all tracked entities related to parent entity if parent is deleteed
            //No Action
            //No Action In Db


            //5-Client Set Null
            //Ef Core will delete In memory tracked Parent [Principal] and Update All Tracked Children [Fk] to be its new value =null
            //No Action In Db

            //6-Client No Action
            //Ef Core will pass deleted entities and doesn't do anyhting with them in application
            //Mapped In Db:No Action   : send request in Db : DATABASE TOTALLY PREVENT FROM APP


            // 7- Restrict:  
            //Ef Core will prevent delete of children if the parent tried to be deleted [Principal]
            // No Send to any request [Delete] to db i will throw here in Application [0%] resiponsibility on database
            // No ActiON in Db





        }

    }





}


