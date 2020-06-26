using DataAccess.Repositories;
using Model.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessTest.Repositories.PostRepositoryTests
{
    public class AbstractRespositoryTest
    {
        private DataAccess.Core.BaseContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new DataAccess.Core.BaseContext(Effort.DbConnectionFactory.CreateTransient(), new PostRepositoryInit());
        }

        #region GetNearbyPosts tests
        [Test]
        [Ignore("TODO: how to use Effort.EF with sql functions ")]
        public void GetNearbyPosts()
        {
            //TODO: how to use Effort.EF with sql functions 
        }

        #endregion
    }
}