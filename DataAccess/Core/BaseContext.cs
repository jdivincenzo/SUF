using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Model.Entities;
using System;

namespace DataAccess.Core
{
    public class BaseContext : DbContext, IBaseContext
    {
        private static bool _seeded = false;

        public BaseContext(ISeeder seeder) : base()
        {
            this.Database.EnsureCreated();
            this.Seed(seeder);
        }

        public BaseContext(DbContextOptions options, ISeeder seeder) : base(options)
        {
            this.Database.EnsureCreated();
            this.Seed(seeder);
        }

        public void Seed(ISeeder seeder)
        {
            if (!_seeded || seeder.Transient())
            {
                CleanContext();
                seeder.Seed(this);
                _seeded = true;
            }
        }

        public void CleanContext()
        {
            this.Posts.RemoveRange(this.Posts);
            this.Pictures.RemoveRange(this.Pictures);
            this.SaveChanges();
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        //This method is for in-memory testing. Dev/prod use db function
        [DbFunction("CalculateDistance")]
        public static double CalculateDistance(double Lat1, double Lon1, double Lat2, double Lon2)
        {
            double rlat1 = Math.PI * Lat1 / 180;
            double rlat2 = Math.PI * Lat2 / 180;
            double theta = Lon1 - Lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return dist * 16.09344;
        }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DatabaseFacade GetDatabase()
        {
            return this.Database;
        }
    }
}