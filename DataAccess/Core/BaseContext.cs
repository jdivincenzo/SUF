using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;

namespace DataAccess.Core
{
    public class BaseContext : DbContext
    {
        private readonly ISeeder _seeder;

        public BaseContext(ISeeder seeder) : base()
        {
            this.Database.EnsureCreated();
            _seeder = seeder;
        }

        public BaseContext(DbContextOptions options, ISeeder seeder) : base(options)
        {
            this.Database.EnsureCreated();
            _seeder = seeder;
        }

        public void Seed()
        {
            _seeder.Seed(this);
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
    }
}