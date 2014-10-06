using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using Chinook.Data.Repository;
using Chinook.Domain.Entities;
using Chinook.Web.UI.Controllers.APi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Chinook.Web.UI.Tests.Controllers.Api
{
    [TestClass()]
    public class ArtistApiControllerTests
    {
        private Mock<IArtistRepository> _artistRepository;

        private ArtistApiController _target;
        
        private List<Artist> _expectedallArtists = new List<Artist> { new Artist(1,"AC/DC"),
                                                                    new Artist(2,"Accept"),
                                                                    new Artist(3,"Aerosmith"),
                                                                    new Artist(4,"Alanis Morissette"),
                                                                    new Artist(5,"Alice In Chains"),
                                                                    new Artist(6,"Antônio Carlos Jobim"),
                                                                    new Artist(7,"Apocalyptica"),
                                                                    new Artist(8,"Audioslave"),
                                                                    new Artist(9,"BackBeat"),
                                                                    new Artist(10,"Billy Cobhamv")
                                                                        };

        [TestInitialize]
        public void Init()
        {
            _artistRepository = new Mock<IArtistRepository>();


            _target = new ArtistApiController(
                _artistRepository.Object)
            {
                Request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost/api/artists")
                }
            };
        }

        [TestMethod()]
        public void GetData_ShouldReturnAllArtists()
        {
            _artistRepository
                .Setup(it => it.GetData())
                .Returns(_expectedallArtists);

            var result = _target.GetData().ToList();
            Assert.AreEqual(_expectedallArtists.Count, result.Count);
        }


        [TestMethod()]
        public void GetDataPageable_ShouldReturnPagedArtists()
        {
            PagedResult<Artist> expectedResult;
      
            _artistRepository
                .Setup(it => it.GetDataPageable(null,1,2))
                .Returns(_expectedallArtists.Take(2).ToList);

            _artistRepository
               .Setup(it => it.GetRowCount())
               .Returns(_expectedallArtists.Count);
            
           var config = new HttpConfiguration();
          
            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();
           
            _target.Request.SetConfiguration(config);

            var result = _target.GetDataPageable(null,1,2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_expectedallArtists.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_expectedallArtists.ToList().Count, expectedResult.TotalCount);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDataByArtistIdTest()
        {
            Assert.Fail();
        }
    }
}
