using DataAccess.Repositories;
using Model.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessTest.Repositories.AbstractRepositoryTests
{
    public class AbstractRespositoryTest
    {
        private DataAccess.Core.BaseContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new TestContext(new BaseRepositorySeeder());
            new SeedRepository(_context).Seed(); //TODO: Automatizar
        }

        #region GatAll tests
        [Test]
        public void GetAllCount()
        {
            var repo = new PostRepository(_context);
            List<Post> res = repo.GetAll().ToList();
            Assert.True(res.Count() == 2);

            var repo2 = new PictureRepository(_context);
            List<Picture> res2 = repo2.GetAll().ToList();
            Assert.True(res2.Count() == 3);
        }

        #endregion
    }
}