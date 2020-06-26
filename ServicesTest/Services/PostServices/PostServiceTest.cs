using Model.Entities;
using NUnit.Framework;
using Services.PostServices;
using System.Collections.Generic;
using Services.PostServices.ExternalModel;
using System.Linq;
using System;

namespace ServicesTest.Services.PostServices
{
    public class PostServiceTest
    {
        private DataAccess.Core.BaseContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new DataAccess.Core.BaseContext(Effort.DbConnectionFactory.CreateTransient(), new PostServiceInit());
        }

        #region GetNearby tests
        [Test]
        [Ignore("TODO: how to use Effort.EF with sql functions ")]
        public void GetNearbyCount()
        {
            //TODO: how to use Effort.EF with sql functions
        }

        #endregion

        #region GetPost tests
        [Test]
        public void GetPostOk()
        {
            var service = new PostService(_context);
            GetPostReturn res = service.GetPost(new GetPostInvoke { Id = 1 });
            Assert.NotNull(res);
        }

        [Test]
        public void GetPostNotExists()
        {
            var service = new PostService(_context);
            Assert.Throws<Exception>(() => service.GetPost(new GetPostInvoke { Id = 11227 }));
        }

        #endregion

        #region CreatePost test
        [Test]
        public void CreatePostWithoutFiles()
        {
            var service = new PostService(_context);
            Assert.Throws<Exception>(() => service.CreatePost(new CreatePostInvoke { Lat = -34.629405, Lon = -58.691752 }));
        }
        #endregion
    }
}