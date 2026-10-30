using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01EfCore.Models
{
   
    internal class Employee
    {

        public int EmpId { get; set; }  


        public string? EmpName { get; set; }

        public decimal Salary { get; set; }

        public int Age { get; set; }


        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }


      
        public string UserName => Email.Split('@')[0];

        #region Manage Relatoionship [Employee-Department [One:One] [O:T]
       // [InverseProperty(nameof(Department.Manager))]
        public Department? ManagedDepartment { get; set; }
        #endregion

        #region Employee has address [1:1 total from both sides]

        public Address EmpAddress { get; set; } = null!;
        #endregion

        #region Employee work in Department [1:M] [Total Participation]
        //[ForeignKey(nameof(WorkingDepartment))]
        public int DeptId { get; set; }

        //[InverseProperty(nameof(Department.Employees))]
        public Department WorkingDepartment { get; set; } = null!;
        #endregion


    }
}
