using Crud_Ajax_Api.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace Crud_Ajax_Api.DataBase
{
    public class DbContext_Crud : DbContext
    {
        public DbContext_Crud(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers {get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //string connectionString = "Server=(local);Database=ApiAjaxCrud; encrypt=false;Integrated Security=true Trusted_Connection=True;";
            //optionsBuilder.UseSqlServer(connectionString);

        }







    }
}
