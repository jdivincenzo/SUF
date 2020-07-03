using DataAccess.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessTest.Core
{
    public class DataAccessTestContext : BaseContext
    {
        public DataAccessTestContext(ISeeder seeder) : base(new DbContextOptionsBuilder<DataAccessTestContext>().UseInMemoryDatabase(databaseName: "DataAccessTest").Options, seeder)
        {
            this.Database.EnsureCreated();
        }
    }
}
