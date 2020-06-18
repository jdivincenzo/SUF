using DataAccess.DatabaseConfig;
using DataAccess.DatabaseInit;
using Model.Entities;
using System.Data.Entity;

namespace DataAccess.Core
{
    public class AppContext : DbContext
    {
        public AppContext() : base("Name=dbPrueba")
        {
            Database.SetInitializer<AppContext>(new AppDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public DbSet<Picture> Pictures { get; set; }
    }
}