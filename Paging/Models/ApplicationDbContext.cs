using System.Data.Entity;

namespace Paging.Models
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public ApplicationDbContext(): base("DefaultConnection") {}
        /// <summary>
        /// 
        /// </summary>
        static ApplicationDbContext()
        {
            System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public DbSet<Persons> Persons { get; set; }
    }
}