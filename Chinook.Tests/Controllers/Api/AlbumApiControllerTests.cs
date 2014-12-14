using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chinook.Data.Repository;
using Chinook.Domain.Entities;
using Chinook.UI.Web.Controllers.Api;
using Chinook.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Chinook.UI.Web.Tests.Controllers.Api
{
    [TestClass()]
    public class AlbumApiControllerTests
    {

        private Mock<IAlbumRepository> _repository;

        private List<Album> _repositoryList = new List<Album>
        {
            new Album(1,"For Those About To Rock We Salute You",1),
            new Album(2,"Balls to the Wall",2),
            new Album(3,"Restless and Wild",2),
            new Album(4,"Let There Be Rock",1),
            new Album(5,"Big Ones",3),
            new Album(6,"Jagged Little Pill",4),
            new Album(7,"Facelift",5),
            new Album(8,"Warner 25 Anos",6),
            new Album(9,"Plays Metallica By Four Cellos",7),
            new Album(10,"Audioslave",8)
        };

        private AlbumApiController _target;

        [TestInitialize]
        public void Init()
        {
            _repository = new Mock<IAlbumRepository>();
            _target = new AlbumApiController(_repository.Object)
            {
                Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/api/albums") }
            };

            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();

            _target.Request.SetConfiguration(config);
        }

        
        [TestMethod()]
        public void GetData_Should_Return_All_Albums()
        {
            _repository
                .Setup(it => it.GetData())
                .Returns(_repositoryList);

            var result = _target.GetData().ToList();
            Assert.AreEqual(_repositoryList.Count, result.Count);
        }

        [TestMethod()]
        public void Update_Should_Update_An_Album()
        {
            var iniCount = _repositoryList.Count();
            _repository.Setup(x => x.Update(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>()))
                .Callback<Int32, String, Int32>((id, title, artistId) =>
                {
                    _repositoryList.Find(x => x.AlbumId == id).Title = title;

                });

            _target.Update(new Album(10, "Big Balls", 1));
            Assert.AreEqual("Big Balls", _repositoryList.Find(x => x.AlbumId == 10).Title);
        }

        [TestMethod()]
        public void Insert_Should_Insert_An_Album()
        {
            var iniCount = _repositoryList.Count();
            _repository.Setup(x => x.Insert(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>()))
                .Returns<Int32, String, Int32>((id, name,artistId) =>
                {
                    _repositoryList.Add(new Album(id, name,artistId));
                    return id;
                });

            Int32 result = _target.Insert(new Album(11, "Big Balls", 1));
            Assert.AreEqual(11, _repositoryList.Count());
            Assert.AreNotEqual(iniCount, _repositoryList.Count());
        }

        [TestMethod()]
        public void Delete_Should_Delete_An_Album()
        {
            var iniCount = _repositoryList.Count();
            _repository.Setup(x => x.Delete(It.IsAny<Int32>()))
                .Callback<Int32>(x =>
                {
                    var i = _repositoryList.FindIndex(q => q.AlbumId.Equals(x));
                    _repositoryList.RemoveAt(i);
                });
            HttpResponseMessage result = _target.Delete(1);
            Assert.AreEqual(iniCount - 1, _repositoryList.Count());
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod()]
        public void GetDataPageable_Should_Return_Paged_Albums()
        {
            PagedResult<Album> expectedResult;

            _repository
                .Setup(it => it.GetDataPageable(It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                .Returns<string, Int32, Int32>((sort, page, size) =>
                {
                    var query = _repositoryList;
                    switch (sort)
                    {
                        case "ArtistId":
                            query = new List<Album>(query.OrderBy(q => q.ArtistId));
                            break;
                        case "AlbumId":
                            query = new List<Album>(query.OrderBy(q => q.AlbumId));
                            break;
                        case "Title":
                            query = new List<Album>(query.OrderBy(q => q.Title));
                            break;
                    }
                    return query.Take(size).Skip((page - 1) * size).ToList();
                });

            _repository
                    .Setup(it => it.GetRowCount())
                    .Returns(_repositoryList.Count);


            var result = _target.GetDataPageable("Title", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.Title).FirstOrDefault().Title, expectedResult.Results.FirstOrDefault().Title);
            Assert.AreEqual(_repositoryList.ToList().Count, expectedResult.TotalCount);
        }

        [TestMethod()]
        public void GetDataByAlbumIdTest()
        {
            

            _repository
                .Setup(it => it.GetDataByAlbumId(It.IsAny<Int32>()))
                .Returns<Int32>((albumId) =>
                {
                    var query = _repositoryList;

                    return query.Where(x => x.AlbumId == albumId).ToList();
                });

            var result = _target.GetDataByAlbumId(1);
            Assert.AreEqual(_repositoryList.Where(x => x.AlbumId == 1).FirstOrDefault().Title, result.FirstOrDefault().Title);
        }

        [TestMethod()]
        public void GetDataByArtistIdTest()
        {
          
            _repository
                .Setup(it => it.GetDataByArtistId(It.IsAny<Int32>()))
                .Returns<Int32>((artistId) =>
                {
                    var query = _repositoryList;
                   
                    return query.Where(x => x.ArtistId == artistId).ToList();
                });

            var result = _target.GetDataByArtistId(1);
            Assert.AreEqual(_repositoryList.Where(x => x.ArtistId == 1).ToList().Count, result.Count());
        }

        [TestMethod()]
        public void GetDataByArtistIdPageable_Should_Return_Paged_Albums_By_A_Selected_Artist()
        {
            PagedResult<Album> expectedResult;

            _repository
                .Setup(it => it.GetDataByArtistIdPageable( It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                .Returns<Int32, string, Int32, Int32>((artistId, sort, page, size) =>
                {
                    var query = _repositoryList;
                    switch (sort)
                    {
                        case "ArtistId":
                            query = new List<Album>(query.OrderBy(q => q.ArtistId));
                            break;
                        case "AlbumId":
                            query = new List<Album>(query.OrderBy(q => q.AlbumId));
                            break;
                        case "Title":
                            query = new List<Album>(query.OrderBy(q => q.Title));
                            break;
                    }
                    return query.Where(x=> x.ArtistId == artistId).Take(size).Skip((page - 1) * size).ToList();
                });

            _repository
                    .Setup(it => it.GetDataByArtistIdRowCount( It.IsAny<Int32>()))
                    .Returns<Int32>((artistId) => _repositoryList.Where(x => x.ArtistId == artistId).ToList().Count);


            var result = _target.GetDataByArtistIdPageable(1, "Title", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));

            Assert.AreEqual(_repositoryList.Where(x => x.ArtistId == 1).ToList().Count, expectedResult.TotalCount);
            Assert.AreEqual(_repositoryList.Where(x => x.ArtistId == 1).OrderBy(q => q.Title).FirstOrDefault().Title, expectedResult.Results.FirstOrDefault().Title);
        }
    }
}
