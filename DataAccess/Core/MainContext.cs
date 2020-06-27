using CodeFirstStoreFunctions;
using DataAccess.DatabaseConfig;
using DataAccess.DatabaseInit;
using Model.Entities;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DataAccess.Core
{
    public class MainContext : BaseContext
    {
        public MainContext() : base()
        {
            Database.SetInitializer<MainContext>(new AppDBInitializer());
        }
    }
}