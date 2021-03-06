﻿using Microsoft.EntityFrameworkCore;

namespace DataAccess.Core
{
    public class DevContext : BaseContext
    {
        public DevContext(ISeeder seeder) : base(seeder)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;Database=Dev;Integrated Security=True"); //windows
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Dev;User id=sa;Password=jdvSqlserver1;"); //linux
        }
    }
}