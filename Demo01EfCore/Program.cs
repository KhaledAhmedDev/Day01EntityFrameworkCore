using Demo01EfCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Demo01EfCore
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using CompanyDbContext dbContext = new CompanyDbContext();  //open connection with DB

            #region Context Setup
            // await dbContext.Database.MigrateAsync(); // Auto Apply any pending migrations
            //Database Connection:Unmanaged resource
            //CLR Will not deal with dbcontext object in heap

            //try
            //{

            //}
            //catch(Exception ex)
            //{

            //}
            //finally
            //{
            //    dbContext.Dispose();
            //    //Deaalocation object from heap
            //    //connection is closed
            //}


            //using CompanyDbContext dbContext = new CompanyDbContext()
            //{



            //}; 
            #endregion

        }
    }
}
