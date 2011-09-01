using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcTechdaysBlog.Models
{
    public class DataService : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}