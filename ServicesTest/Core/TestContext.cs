using CodeFirstStoreFunctions;
using DataAccess.Core;
using DataAccess.DatabaseConfig;
using DataAccess.DatabaseInit;
using Model.Entities;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ServicesTest.Core
{
    public class TestContext : DevContext
    {
        public TestContext() : base(Effort.DbConnectionFactory.CreateTransient(), new TestDBInitializer())
        {
            Database.SetInitializer<TestContext>(new TestDBInitializer());
        }

        protected override void Dispose(bool disposing) // Override to avoid tested project to dispose the conext
        {
        }
        public void DisposeContext()    // For mannually dispose on 
        {
            base.Dispose();
        }
    }
}