using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Chinook.Data.Repository;
using Chinook.Domain.Entities;
using Chinook.UI.Web.Controllers.APi;
using Chinook.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Chinook.UI.Web.Tests.Controllers.Api
{
    [TestClass()]
    public class ArtistApiControllerTests
    {
        private Mock<IArtistRepository> _repository;

        private List<Artist> _repositoryList = new List<Artist>
        {
            new Artist(1, "Alanis Morissette"),
            new Artist(2, "Alice In Chains"),
            new Artist(3, "Antônio Carlos Jobim"),
            new Artist(7, "Apocalyptica"),
            new Artist(8, "Audioslave"),
            new Artist(9, "BackBeat"),
            new Artist(10, "Billy Cobhamv"),
            new Artist(4, "AC/DC"),
            new Artist(5, "Accept"),
            new Artist(6, "Aerosmith")
        };

        private ArtistApiController _target;

        [TestInitialize]
        public void Init()
        {
            _repository = new Mock<IArtistRepository>();
            _target = new ArtistApiController(_repository.Object)
            {
                Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/api/artists") }
            };

            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();

            _target.Request.SetConfiguration(config);
        }

        [TestMethod()]
        public void GetData_ShouldReturnAllArtists()
        {
            _repository
                .Setup(it => it.GetData())
                .Returns(_repositoryList);

            var result = _target.GetData().ToList();
            Assert.AreEqual(_repositoryList.Count, result.Count);
        }


        [TestMethod()]
        public void GetDataPageable_ShouldReturnPagedArtists()
        {
            PagedResult<Artist> expectedResult;

            _repository
                .Setup(it => it.GetDataPageable(It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                .Returns<string, Int32, Int32>((sort, page, size) =>
                {
                    var query = _repositoryList;
                    switch (sort)
                    {
                        case "ArtistId":
                            query = new List<Artist>(query.OrderBy(q => q.ArtistId));
                            break;
                        case "Name":
                            query = new List<Artist>(query.OrderBy(q => q.Name));
                            break;
                      }
                    return query.Take(size).Skip((page-1)*size).ToList();
                });

          _repository
                  .Setup(it => it.GetRowCount())
                  .Returns(_repositoryList.Count);


          var result = _target.GetDataPageable("Name", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.Name).FirstOrDefault().Name, expectedResult.Results.FirstOrDefault().Name);
            Assert.AreEqual(_repositoryList.ToList().Count, expectedResult.TotalCount);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var iniCount = _repositoryList.Count();
            _repository.Setup(x => x.Update(It.IsAny<Int32>(), It.IsAny<String>()))
                .Callback<Int32, String>((id, name) =>
                {
                     _repositoryList.Find(x => x.ArtistId == id).Name = name;
                   
                });

            _target.Update(new Artist(10, "Korn"));
      Assert.AreEqual("Korn", _repositoryList.Find(x => x.ArtistId == 10).Name);
      }

        [TestMethod()]
        public void InsertTest()
        {
            var iniCount = _repositoryList.Count();
            _repository.Setup(x => x.Insert(It.IsAny<Int32>(), It.IsAny<String>()))
                .Returns<Int32, String>((id,name) =>
                {
                    _repositoryList.Add(new Artist(id,name));
                    return id;
                });

            Int32 result = _target.Insert(new Artist( 11, "Korn"));
            Assert.AreEqual(11, _repositoryList.Count());
            Assert.AreNotEqual(iniCount, _repositoryList.Count());
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var iniCount = _repositoryList.Count();
            _repository.Setup(x => x.Delete(It.IsAny<Int32>()))
                .Callback<Int32>(x =>
                {
                    var i = _repositoryList.FindIndex(q => q.ArtistId.Equals(x));
                    _repositoryList.RemoveAt(i);
                });
            HttpResponseMessage result = _target.Delete(1);
            Assert.AreEqual(iniCount - 1, _repositoryList.Count());
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod()]
        public void GetDataByArtistIdTest()
        {
            _repository
                 .Setup(it => it.GetDataByArtistId(It.IsAny<Int32>()))
                 .Returns<Int32>((artistId) =>(ICollection<Artist>)_repositoryList.Where(x => x.ArtistId == artistId).ToList());

            var result = _target.GetDataByArtistId(1).ToList();
            var firstOrDefault = _repositoryList.FirstOrDefault();
            if (firstOrDefault == null) return;
            var orDefault = result.FirstOrDefault();
            if (orDefault != null) Assert.AreEqual(firstOrDefault.Name, orDefault.Name);
        }
    }
}