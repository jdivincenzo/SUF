﻿using CodeFirstStoreFunctions;
using DataAccess.DatabaseConfig;
using DataAccess.DatabaseInit;
using Model.Entities;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DataAccess.Core
{
    public class DevContext : DbContext
    {
        public DevContext() : base("Name=dbPrueba")
        {
            Database.SetInitializer<DevContext>(new AppDBInitializer());
        }

        public DevContext(DbConnection connection, DropCreateDatabaseAlways<DevContext> init) : base(connection, contextOwnsConnection: true) // required by Effort.EF6
        {
            Database.SetInitializer<DevContext>(init);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new FunctionsConvention("dbo", this.GetType()));
        }

        //This function is defined as database function for performance reasons
        [DbFunction("CodeFirstDatabaseSchema", "CalculateDistance")]
        public double CalculateDistance(double Lat1, double Lon1, double Lat2, double Lon2)
        {
            throw new NotImplementedException();
        }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}