using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DataBases
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RssChanel> RssChanels { get; set; }
        public DbSet<RssItem> RssItems { get; set; }

        public ApplicationContext(): base("DbConnection")
        {
            Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => new { u.Id });
            modelBuilder.Entity<RssChanel>().HasKey(rc => new { rc.Id});
            modelBuilder.Entity<RssItem>().HasKey(ri => new { ri.Id});
            modelBuilder.Entity<UserContent>().HasKey( uc => uc.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}