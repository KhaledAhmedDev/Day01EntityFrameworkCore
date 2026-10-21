using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01EfCore.Models
{
    //Model-POCO :plain old c# object-Entity-Domain Entity
    internal class Product
    {
        //Search for Integral Property [Int-Long-short]
        //Not any numerical Property must ist name be Id or Entity Followed By Id [Id-ProductId]
        //Once it found ,it will recognize as pk
        //By Default any choosen integral properties to be as pk ,auto genrrated by 1 and 1 [Identity Constraint(1,1]
        //if No integral properties it will search for property [string,Guid] must its name either Id or EntityFollowedById
        // No Identity Constraint is put

        public int Id { get; set; }  //Primary key

        //nullable reference type
        //nvarchar(max)
        //Allow Null in Db
        public string? Name { get; set; }

        //Non Nullable value Type
        //mapped as decimal(18,2)
        //Not allow null

        public decimal Price { get; set; }

        //Non-Nullable value Type
        //Mapped into Int
        //Not allow null

        public int Stock { get; set; }


       
       
    }
}
