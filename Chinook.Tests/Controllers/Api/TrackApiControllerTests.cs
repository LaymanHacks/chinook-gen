﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chinook.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Chinook.Data.Repository;
using Chinook.Domain.Entities;
using Chinook.UI.Web.Controllers.Api;

namespace Chinook.UI.Web.Tests.Controllers.Api
{
    [TestClass()]
    public class TrackApiControllerTests
    {

        private Mock<ITrackRepository> _repository;

        private List<Track> _repositoryList = new List<Track>
        {
            new Track(1, "For Those About To Rock (We Salute You)",1,1,1,"Angus Young, Malcolm Young, Brian Johnson",343719,11170334 ,0.99m),
            new Track(2,"Balls to the Wall",2,2,1,"",342562,5510424,0.99m),
            new Track(3,"Fast As a Shark",3,2,1,"F. Baltes, S. Kaufman, U. Dirkscneider & W. Hoffman",230619,3990994,0.99m),
            new Track(4,"Restless and Wild",3,2,1,"F. Baltes, R.A. Smith-Diesel, S. Kaufman, U. Dirkscneider & W. Hoffman",252051,4331779,0.99m),
            new Track(5,"Princess of the Dawn",3,2,1,"Deaffy & R.A. Smith-Diesel",375418,6290521,0.99m),
            new Track(6,"Put The Finger On You",1,1,1,"Angus Young, Malcolm Young, Brian Johnson",205662,6713451,0.99m),
            new Track(7,"Let's Get It Up",1,1,1,"Angus Young, Malcolm Young, Brian Johnson",233926,7636561,0.99m),
            new Track(8,"Inject The Venom",1,1,1,"Angus Young, Malcolm Young, Brian Johnson",210834,6852860,0.99m),
            new Track(9,"Snowballed",1,1,1,"Angus Young, Malcolm Young, Brian Johnson",203102,6599424,0.99m),
            new Track(10, "Evil Walks",1,1,1,"Angus Young, Malcolm Young, Brian Johnson",263497,8611245,0.99m)
        };

        private TrackApiController _target;

        [TestInitialize]
        public void Init()
        {
            _repository = new Mock<ITrackRepository>();
            _target = new TrackApiController(_repository.Object)
            {
                Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/api/Tracks") }
            };

            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();

            _target.Request.SetConfiguration(config);
        }

        [TestMethod()]
        public void GetDataTest()
        {
            _repository
                 .Setup(it => it.GetData())
                     .Returns(_repositoryList);

            var result = _target.GetData().ToList();
            Assert.AreEqual(_repositoryList.ToList().Count, result.Count);
        }

        [TestMethod()]
        public void Update_Should_Update_A_Track()
        {
            _repository
                 .Setup(it => it.Update(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32?>(), It.IsAny<Int32>(), It.IsAny<Int32?>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32?>(), It.IsAny<Decimal>()))
                 .Callback<Int32, String, Int32?, Int32, Int32?, String, Int32, Int32?, Decimal>((trackId, name, albumId, mediaTypeId, genreId, composer, milliseconds, bytes, unitPrice) =>
                 {
                     var tTrack = _repositoryList.Find(x => x.TrackId == trackId);
                     tTrack.Name = name;
                     tTrack.AlbumId = albumId;
                     tTrack.MediaTypeId = mediaTypeId;
                     tTrack.GenreId = genreId;
                     tTrack.Composer = composer;
                     tTrack.Milliseconds = milliseconds;
                     tTrack.Bytes = bytes;
                     tTrack.UnitPrice = unitPrice;
                 });
            var tempTrack = _repositoryList.Find(x => x.TrackId == 1);
            var testTrack = new Track
            {
                TrackId = tempTrack.TrackId,
                Name = tempTrack.Name,
                AlbumId = tempTrack.AlbumId,
                MediaTypeId = tempTrack.MediaTypeId,
                GenreId = tempTrack.GenreId,
                Composer = tempTrack.Composer,
                Milliseconds = tempTrack.Milliseconds,
                Bytes = tempTrack.Bytes,
                UnitPrice = tempTrack.UnitPrice
            };

           testTrack.Name = "newValue"; 
            _target.Update(testTrack);
            Assert.AreEqual("newValue", _repositoryList.Find(x => x.TrackId == 1).Name);
           
        }

        [TestMethod()]
        public void Insert_Should_Insert_A_Track()
        {
            _repository
                 .Setup(it => it.Insert(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32?>(), It.IsAny<Int32>(), It.IsAny<Int32?>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32?>(), It.IsAny<Decimal>()))
                 .Returns<Int32, String, Int32?, Int32, Int32?, String, Int32, Int32?, Decimal>((trackId, name, albumId, mediaTypeId, genreId, composer, milliseconds, bytes, unitPrice) =>
                 {
                     _repositoryList.Add(new Track(trackId, name, albumId, mediaTypeId, genreId, composer, milliseconds, bytes, unitPrice));
                     return trackId;
                 });

           
            _target.Insert(new Track(11, "name", 1, 1, 1, "composer", 1, 1, 1m));
            Assert.AreEqual(11, _repositoryList.Count());
           
        }

        [TestMethod()]
        public void Delete_Should_Delete_A_Track()
        {
            _repository
                 .Setup(it => it.Delete(It.IsAny<Int32>()))
                 .Callback<Int32>((trackId) =>
                 {
                     var i = _repositoryList.FindIndex(q => q.TrackId == trackId);
                     _repositoryList.RemoveAt(i);
                 });
            var iniCount = _repositoryList.Count();
            HttpResponseMessage result = _target.Delete(1);
            Assert.AreEqual(iniCount - 1, _repositoryList.Count());
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod()]
        public void GetDataPageableTest()
        {
            PagedResult<Track> expectedResult;

            _repository
                 .Setup(it => it.GetDataPageable(It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<String, Int32, Int32>((sortExpression, page, pageSize) =>
                 {
                     var query = _repositoryList;
                     switch (sortExpression)
                     {
                         case "TrackId":
                             query = new List<Track>(query.OrderBy(q => q.TrackId));
                             break;
                         case "Name":
                             query = new List<Track>(query.OrderBy(q => q.Name));
                             break;
                         case "AlbumId":
                             query = new List<Track>(query.OrderBy(q => q.AlbumId));
                             break;
                         case "MediaTypeId":
                             query = new List<Track>(query.OrderBy(q => q.MediaTypeId));
                             break;
                         case "GenreId":
                             query = new List<Track>(query.OrderBy(q => q.GenreId));
                             break;
                         case "Composer":
                             query = new List<Track>(query.OrderBy(q => q.Composer));
                             break;
                         case "Milliseconds":
                             query = new List<Track>(query.OrderBy(q => q.Milliseconds));
                             break;
                         case "Bytes":
                             query = new List<Track>(query.OrderBy(q => q.Bytes));
                             break;
                         case "UnitPrice":
                             query = new List<Track>(query.OrderBy(q => q.UnitPrice));
                             break;
                     }
                     return query.Take(pageSize).Skip((page - 1) * pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetRowCount())
                 .Returns(_repositoryList.Count);

            var result = _target.GetDataPageable("TrackId", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.TrackId).FirstOrDefault().TrackId, expectedResult.Results.FirstOrDefault().TrackId);
        }

        [TestMethod()]
        public void GetDataByTrackIdTest()
        {
            _repository
                 .Setup(it => it.GetDataByTrackId(It.IsAny<Int32>()))
                     .Returns<Int32>((trackId) =>
                     {
                         return _repositoryList.Where(x => x.TrackId == trackId).ToList();
                     });

            var result = _target.GetDataByTrackId(1).ToList();
            Assert.AreEqual(_repositoryList.Where(x => x.TrackId == 1).ToList().Count, result.Count);
        }

        [TestMethod()]
        public void GetTracksByPlaylistIdTest()
        {
            //_repository
            //     .Setup(it => it.GetTracksByPlaylistId(It.IsAny<Int32>()))
            //         .Returns<Int32>((playlistId) =>
            //         {
            //             return _repositoryList.Where(x => x.Playlists.PlaylistId == playlistId).ToList();
            //         });

            //var result = _target.GetTracksByPlaylistId(1).ToList();
            //_repositoryList.Where(x => x.PlaylistId == 1).ToList().Count, result.Count);
            //Need to work on mocking this function so fail for now
            Assert.Fail();
            
        }

        [TestMethod()]
        public void GetTracksByPlaylistIdPageableTest()
        {
            PagedResult<Track> expectedResult;

            _repository
                 .Setup(it => it.GetTracksByPlaylistIdPageable(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<Int32, String, Int32, Int32>((playlistId, sortExpression, page, pageSize) =>
                 {
                     var query = _repositoryList;
                     switch (sortExpression)
                     {
                         case "TrackId":
                             query = new List<Track>(query.OrderBy(q => q.TrackId));
                             break;
                         case "Name":
                             query = new List<Track>(query.OrderBy(q => q.Name));
                             break;
                         case "AlbumId":
                             query = new List<Track>(query.OrderBy(q => q.AlbumId));
                             break;
                         case "MediaTypeId":
                             query = new List<Track>(query.OrderBy(q => q.MediaTypeId));
                             break;
                         case "GenreId":
                             query = new List<Track>(query.OrderBy(q => q.GenreId));
                             break;
                         case "Composer":
                             query = new List<Track>(query.OrderBy(q => q.Composer));
                             break;
                         case "Milliseconds":
                             query = new List<Track>(query.OrderBy(q => q.Milliseconds));
                             break;
                         case "Bytes":
                             query = new List<Track>(query.OrderBy(q => q.Bytes));
                             break;
                         case "UnitPrice":
                             query = new List<Track>(query.OrderBy(q => q.UnitPrice));
                             break;
                     }
                     return query.Take(pageSize).Skip((page - 1) * pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetTracksByPlaylistIdRowCount(1))
                 .Returns(_repositoryList.Count);

            var result = _target.GetTracksByPlaylistIdPageable(1, "TrackId", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.TrackId).FirstOrDefault().TrackId, expectedResult.Results.FirstOrDefault().TrackId);
        }

        [TestMethod()]
        public void GetDataByAlbumIdTest()
        {
            _repository
                 .Setup(it => it.GetDataByAlbumId(It.IsAny<Int32>()))
                     .Returns<Int32>((albumId) =>
                     {
                         return _repositoryList.Where(x => x.AlbumId == albumId).ToList();
                     });

            var result = _target.GetDataByAlbumId(1).ToList();
            Assert.AreEqual(_repositoryList.Where(x => x.AlbumId == 1).ToList().Count, result.Count);
        }

        [TestMethod()]
        public void GetDataByAlbumIdPageableTest()
        {
            PagedResult<Track> expectedResult;

            _repository
                 .Setup(it => it.GetDataByAlbumIdPageable(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<Int32, String, Int32, Int32>((albumId, sortExpression, page, pageSize) =>
                 {
                     var query = _repositoryList.Where(x => x.AlbumId == albumId);
                     switch (sortExpression)
                     {
                         case "TrackId":
                             query = new List<Track>(query.OrderBy(q => q.TrackId));
                             break;
                         case "Name":
                             query = new List<Track>(query.OrderBy(q => q.Name));
                             break;
                         case "AlbumId":
                             query = new List<Track>(query.OrderBy(q => q.AlbumId));
                             break;
                         case "MediaTypeId":
                             query = new List<Track>(query.OrderBy(q => q.MediaTypeId));
                             break;
                         case "GenreId":
                             query = new List<Track>(query.OrderBy(q => q.GenreId));
                             break;
                         case "Composer":
                             query = new List<Track>(query.OrderBy(q => q.Composer));
                             break;
                         case "Milliseconds":
                             query = new List<Track>(query.OrderBy(q => q.Milliseconds));
                             break;
                         case "Bytes":
                             query = new List<Track>(query.OrderBy(q => q.Bytes));
                             break;
                         case "UnitPrice":
                             query = new List<Track>(query.OrderBy(q => q.UnitPrice));
                             break;
                     }
                     return query.Take(pageSize).Skip((page - 1) * pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetDataByAlbumIdRowCount(1))
                 .Returns(_repositoryList.Count);

            var result = _target.GetDataByAlbumIdPageable(1, "TrackId", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Where(x => x.AlbumId == 1).Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.Where(x => x.AlbumId == 1).OrderBy(q => q.TrackId).FirstOrDefault().TrackId, expectedResult.Results.FirstOrDefault().TrackId);
        }

        [TestMethod()]
        public void GetDataByGenreIdTest()
        {
            _repository
                 .Setup(it => it.GetDataByGenreId(It.IsAny<Int32>()))
                     .Returns<Int32>((genreId) =>
                     {
                         return _repositoryList.Where(x => x.GenreId == genreId).ToList();
                     });

            var result = _target.GetDataByGenreId(1).ToList();
            Assert.AreEqual(_repositoryList.Where(x => x.GenreId == 1).ToList().Count, result.Count);
        }

        [TestMethod()]
        public void GetDataByGenreIdPageableTest()
        {
            PagedResult<Track> expectedResult;

            _repository
                 .Setup(it => it.GetDataByGenreIdPageable(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<Int32, String, Int32, Int32>((genreId, sortExpression, page, pageSize) =>
                 {
                     var query = _repositoryList.Where(x => x.GenreId == genreId);
                     switch (sortExpression)
                     {
                         case "TrackId":
                             query = new List<Track>(query.OrderBy(q => q.TrackId));
                             break;
                         case "Name":
                             query = new List<Track>(query.OrderBy(q => q.Name));
                             break;
                         case "AlbumId":
                             query = new List<Track>(query.OrderBy(q => q.AlbumId));
                             break;
                         case "MediaTypeId":
                             query = new List<Track>(query.OrderBy(q => q.MediaTypeId));
                             break;
                         case "GenreId":
                             query = new List<Track>(query.OrderBy(q => q.GenreId));
                             break;
                         case "Composer":
                             query = new List<Track>(query.OrderBy(q => q.Composer));
                             break;
                         case "Milliseconds":
                             query = new List<Track>(query.OrderBy(q => q.Milliseconds));
                             break;
                         case "Bytes":
                             query = new List<Track>(query.OrderBy(q => q.Bytes));
                             break;
                         case "UnitPrice":
                             query = new List<Track>(query.OrderBy(q => q.UnitPrice));
                             break;
                     }
                     return query.Take(pageSize).Skip((page - 1) * pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetDataByGenreIdRowCount(1))
                 .Returns(_repositoryList.Count);

            var result = _target.GetDataByGenreIdPageable(1, "TrackId", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Where(x => x.GenreId == 1).Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.Where(x => x.GenreId == 1).OrderBy(q => q.TrackId).FirstOrDefault().TrackId, expectedResult.Results.FirstOrDefault().TrackId);
        }

        [TestMethod()]
        public void GetDataByMediaTypeIdTest()
        {
            _repository
                 .Setup(it => it.GetDataByMediaTypeId(It.IsAny<Int32>()))
                     .Returns<Int32>((mediaTypeId) =>
                     {
                         return _repositoryList.Where(x => x.MediaTypeId == mediaTypeId).ToList();
                     });

            var result = _target.GetDataByMediaTypeId(1).ToList();
            Assert.AreEqual(_repositoryList.Where(x => x.MediaTypeId == 1).ToList().Count, result.Count);
        }

        [TestMethod()]
        public void GetDataByMediaTypeIdPageableTest()
        {
            PagedResult<Track> expectedResult;

            _repository
                 .Setup(it => it.GetDataByMediaTypeIdPageable(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<Int32, String, Int32, Int32>((mediaTypeId, sortExpression, page, pageSize) =>
                 {
                     var query = _repositoryList.Where(x => x.MediaTypeId == mediaTypeId);
                     switch (sortExpression)
                     {
                         case "TrackId":
                             query = new List<Track>(query.OrderBy(q => q.TrackId));
                             break;
                         case "Name":
                             query = new List<Track>(query.OrderBy(q => q.Name));
                             break;
                         case "AlbumId":
                             query = new List<Track>(query.OrderBy(q => q.AlbumId));
                             break;
                         case "MediaTypeId":
                             query = new List<Track>(query.OrderBy(q => q.MediaTypeId));
                             break;
                         case "GenreId":
                             query = new List<Track>(query.OrderBy(q => q.GenreId));
                             break;
                         case "Composer":
                             query = new List<Track>(query.OrderBy(q => q.Composer));
                             break;
                         case "Milliseconds":
                             query = new List<Track>(query.OrderBy(q => q.Milliseconds));
                             break;
                         case "Bytes":
                             query = new List<Track>(query.OrderBy(q => q.Bytes));
                             break;
                         case "UnitPrice":
                             query = new List<Track>(query.OrderBy(q => q.UnitPrice));
                             break;
                     }
                     return query.Take(pageSize).Skip((page - 1) * pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetDataByMediaTypeIdRowCount(1))
                 .Returns(_repositoryList.Count);

            var result = _target.GetDataByMediaTypeIdPageable(1, "TrackId", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Where(x => x.MediaTypeId == 1).Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.Where(x => x.MediaTypeId == 1).OrderBy(q => q.TrackId).FirstOrDefault().TrackId, expectedResult.Results.FirstOrDefault().TrackId);
        }


    }
}
