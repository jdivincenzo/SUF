using DataAccess.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesTest.Core
{
    public class ServiceTestContext : BaseContext
    {
        public ServiceTestContext(ISeeder seeder) : base(new DbContextOptionsBuilder<ServiceTestContext>().UseInMemoryDatabase(databaseName: "ServiceTest").Options, seeder)
        {
            this.Database.EnsureCreated();
        }
        public override void Dispose() // Override to avoid tested project to dispose the conext
        {
        }
        public void DisposeContext()    // For mannually dispose on 
        {
            base.Dispose();
        }
    }
}
