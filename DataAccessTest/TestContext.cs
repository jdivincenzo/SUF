using DataAccess.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessTest
{
    public class TestContext : BaseContext
    {
        public TestContext() : base()
        {
            this.Database.EnsureCreated();
        }

        public TestContext(ISeeder seeder) : base(seeder)
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;Database=Dev;Integrated Security=True");
        }
    }
}
