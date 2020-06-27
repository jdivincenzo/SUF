using Model.Entities;
using NUnit.Framework;
using Services.PostServices;
using System.Collections.Generic;
using Services.PostServices.ExternalModel;
using System.Linq;
using System;
using ServicesTest.Core;
using ServicesTest.Fakes;

namespace ServicesTest.Services.PostServices
{
    public class PostServiceTest
    {
        private Core.TestContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new Core.TestContext();
        }

        [TearDown]
        public void TearDown()
        {
            _context.DisposeContext();
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

        [Test]
        public void CreatePostOk()
        {
            var service = new PostService(_context, new FakeFileUtils());
            var prevCount = _context.Posts.Count();
            service.CreatePost(new CreatePostInvoke { Lat = -34.629405, Lon = -58.691752, Files = new List<FileDescriptor> { new FileDescriptor { Filename = "" } } });
            var postCount = _context.Posts.Count();
            Assert.IsTrue(prevCount + 1 == postCount);
        }
        #endregion
    }
}