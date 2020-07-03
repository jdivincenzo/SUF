﻿using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Data.Common;

namespace DataAccess.Core
{
    public class DevContext : BaseContext
    {
        public DevContext() : base()
        {
            this.Database.EnsureCreated();
        }

        public DevContext(ISeeder seeder) : base(seeder)
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;Database=Dev;Integrated Security=True");
        }
    }
}