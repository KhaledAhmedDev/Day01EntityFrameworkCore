using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01EfCore.Models
{
    internal class Department  //HR
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        public DateTime DateOfCreation { get; set; }  // read-only

        public int Serial { get; set; }

        #region Manage Relationship [Employee-Department] [One:One] [O:T]

       // [InverseProperty(nameof(Employee.ManagedDepartment))]
       public Employee Manager { get; set; } = null!;

        //[ForeignKey(nameof(Manager))]
        public int DeptManagerId { get; set; }

        //Property : by convention as Fk
        //Navigationproperty+Id==> ManagerId
        //NavigationProperty+Pk in PRINCIPAL TABLE=>ManagerEmpId
        //Entity of principal+Id  => EmployeeId
        //Entity Of Principal +Pk=> EmployeeEmpId
        #endregion

    }
}
