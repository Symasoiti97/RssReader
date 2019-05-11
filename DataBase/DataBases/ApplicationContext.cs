using DataBase.Models;
using System.Data.Entity;

namespace DataBase.DataBases
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RssChannel> RssChanels { get; set; }
        public DbSet<RssItem> RssItems { get; set; }
        public DbSet<UserContent> UserContents { get; set; }
        public DbSet<UserFavoriteItem> UserFavoriteItems { get; set; }

        public ApplicationContext(): base("DbConnection")
        {
            Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}