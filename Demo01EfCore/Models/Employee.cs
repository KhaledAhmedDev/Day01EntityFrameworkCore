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
    [Table("EmployeesTable")]
    internal class Employee
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpId { get; set; }  //By Convention [Not Pk]

        [Required]
        [Column(name:"EmployeeName",TypeName ="varchar")]
        [MaxLength(50,ErrorMessage ="Name Cannot exceed 50")]  //varchar(50)   varchar(3,50)
        [MinLength(3,ErrorMessage ="Name at least is 3 chars")]  //Application validation
        //[StringLength(50,MinimumLength =3,ErrorMessage ="Name must be between 3 and 50")]
       // [Length(3,50)]  //Application validation not mapped in DB [NO DATABASE APPLY]
        public string? EmpName { get; set; }

        // [Column(TypeName ="decimal(10,3)")]  //Database Apply
        [Precision(10,3)]  //Database Apply
        public decimal Salary { get; set; }

        [Range(22,40)]  //Application validation
        //[AllowedValues(24,26,28,30)]  //Application Validation
        //[DeniedValues(27,29,31)] //Application Validation
        public int Age { get; set; }

        [Required(ErrorMessage ="Email is Required")] //Database Apply
        [EmailAddress] //Application validation
        [DataType(DataType.EmailAddress)] //UI Hint to display value Email addresss to frontend 
        public string Email { get; set; }


        [Required] //Database Apply
        [DataType(DataType.Password)]  // ****** :UI Hint
        public string Password { get; set; }

        [Required] //Database Apply
        [Phone]  //Application validation
        [DataType(DataType.PhoneNumber)]  //UI Hint
        public string Phone { get; set; }


        [NotMapped]  //Database Apply
        public string UserName => Email.Split('@')[0];


    }
}
