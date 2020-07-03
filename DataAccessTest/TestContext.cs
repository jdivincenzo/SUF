using DataAccess.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessTest
{
    public class TestContext : BaseContext
    {
        public TestContext(ISeeder seeder) : base(new DbContextOptionsBuilder<TestContext>().UseInMemoryDatabase(databaseName: "Test").Options, seeder)
        {
            this.Database.EnsureCreated();
        }
    }
}
