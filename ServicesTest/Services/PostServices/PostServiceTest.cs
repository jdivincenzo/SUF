using NUnit.Framework;
using Services.PostServices;
using Services.PostServices.ExternalModel;
using Services.Seed;
using ServicesTest.Core;
using ServicesTest.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesTest.Services.PostServices
{
    public class PostServiceTest
    {
        private ServiceTestContext _context;

        #region Config
        [SetUp]
        public void Setup()
        {
            _context = new ServiceTestContext(new PostServiceSeeder());
            new SeedService(_context).Seed();//TODO: Automatizar
        }

        [TearDown]
        public void TearDown()
        {
            _context.DisposeContext();
        }

        #endregion

        #region GetNearby tests
        [Test]
        public void GetNearbyCount()
        {
            GetNearbyPostsInvoke inv1 = new GetNearbyPostsInvoke { Lat = -34.629835, Lon = -58.694141, Distance = 1 };
            GetNearbyPostsInvoke inv2 = new GetNearbyPostsInvoke { Lat = -34.629835, Lon = -58.694141, Distance = 2 };
            GetNearbyPostsInvoke inv3 = new GetNearbyPostsInvoke { Lat = -34.629835, Lon = -58.694141, Distance = 10 };

            IEnumerable<GetNearbyPostsReturn> posts1 = new PostService(_context).GetNearby(inv1);
            Assert.IsTrue(posts1.Count() == 0);
            IEnumerable<GetNearbyPostsReturn> posts2 = new PostService(_context).GetNearby(inv2);
            Assert.IsTrue(posts2.Count() == 1);
            IEnumerable<GetNearbyPostsReturn> posts3 = new PostService(_context).GetNearby(inv3);
            Assert.IsTrue(posts3.Count() == 2);
        }

        #endregion

        #region GetPost tests
        [Test]
        public void GetPostOk()
        {
            var service = new PostService(_context);
            
            GetPostReturn res = service.GetPost(new GetPostInvoke { Id = _context.Posts.First().PostId });
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
            var prevPostCount = _context.Posts.Count();
            var prevPicCount = _context.Pictures.Count();
            var lat = -34.629405;
            var lon = -58.691752;

            CreatePostReturn cpr = service.CreatePost(new CreatePostInvoke {
                Lat = lat, 
                Lon = lon, 
                Files = new List<FileDescriptor> { 
                    new FileDescriptor { Filename = "fakeFile1" }, 
                    new FileDescriptor { Filename = "fakeFile1" } 
                } 
            });
            var postCount = _context.Posts.Count();
            var picCount = _context.Pictures.Count();

            Assert.IsTrue(prevPostCount + 1 == postCount);
            Assert.IsTrue(prevPicCount + 2 == picCount);
            Assert.IsTrue(lat == cpr.Lat);
            Assert.IsTrue(lon == cpr.Lon);
            Assert.IsNotNull(cpr.Id);
        }

        #endregion
    }
}