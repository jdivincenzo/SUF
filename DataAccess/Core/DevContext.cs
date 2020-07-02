using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Data.Common;

namespace DataAccess.Core
{
    public class DevContext : DbContext
    {
        private ISeeder _seeder;

        public DevContext() : base()
        {
            this.Database.EnsureCreated();
        }

        public DevContext(ISeeder seeder) : base()
        {
            //Database.SetInitializer<DevContext>(new DevDBInitializer());
            this.Database.EnsureCreated();
            _seeder = seeder;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;Database=Dev;Integrated Security=True");
            //this.Database.EnsureCreated();
        }

        public void Seed()
        {
            _seeder.Seed(this);
        }

        [DbFunction("CalculateDistance")]
        public static double CalculateDistance(double Lat1, double Lon1, double Lat2, double Lon2)
        {
            throw new Exception(); // this code doesn't get executed; the call is passed through to the database function
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    Post post1 = new Post() { PostId = -1, Lat = -34.631298, Lon = -58.695334 };
        //    Post post2 = new Post() { PostId = -2, Lat = -34.632455, Lon = -58.696286 };
        //    Post post3 = new Post() { PostId = -3, Lat = -34.633683, Lon = -58.697299 };

        //    Picture p1 = new Picture() { FileName = "Foto 1", Post = post1 };
        //    Picture p2 = new Picture() { FileName = "Foto 2", Post = post2 };
        //    Picture p3 = new Picture() { FileName = "Foto 3", Post = post3 };

        //    modelBuilder.Entity<Post>().HasData(post1);
        //    modelBuilder.Entity<Post>().HasData(post2);
        //    modelBuilder.Entity<Post>().HasData(post3);
        //}


        //public DevContext(DbConnection connection, DropCreateDatabaseAlways<DevContext> init) : base(connection, contextOwnsConnection: true) // required by Effort.EF6
        //{
        //    Database.SetInitializer<DevContext>(init);
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Add(new FunctionsConvention("dbo", this.GetType()));
        //}

        ////This function is defined as database function for performance reasons
        //[DbFunction("CodeFirstDatabaseSchema", "CalculateDistance")]
        //public double CalculateDistance(double Lat1, double Lon1, double Lat2, double Lon2)
        //{
        //    throw new NotImplementedException();
        //}

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}