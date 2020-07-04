using DataAccess.Repositories;
using DataAccessTest.Core;
using Model.Entities;
using NUnit.Framework;
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
            _context = new DataAccessTestContext(new PostRepositorySeeder());
            new SeedRepository(_context).Seed();//TODO: Automatizar
        }

        #region GetNearbyPosts tests
        [Test]
        public void GetNearbyPosts()
        {
            IEnumerable<Post> posts = new PostRepository(_context).GetNearbyPosts(-34.629835, -58.694141, 1); 
            Assert.IsTrue(posts.Count() == 0);
            posts = new PostRepository(_context).GetNearbyPosts(-34.629835, -58.694141, 2); 
            Assert.IsTrue(posts.Count() == 1);
            posts = new PostRepository(_context).GetNearbyPosts(-34.629835, -58.694141, 10); 
            Assert.IsTrue(posts.Count() == 2);
        }

        #endregion
    }
}