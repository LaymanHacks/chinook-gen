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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Chinook.Data.Repository;
using Chinook.Domain.Entities;
using Chinook.Web.UI.Controllers.Api;

namespace Chinook.Web.UI.Test.Controllers.Api
{
    [TestClass()]
    public class PlaylistApiControllerTests
    {

        private Mock<IPlaylistRepository> _repository;

        private List<Playlist> _repositoryList = new List<Playlist>
        {
        //TODO Initialize test data
            new Playlist()
        };

        private PlaylistApiController _target;

        [TestInitialize]
        public void Init()
        {
            _repository = new Mock<IPlaylistRepository>();
            _target = new PlaylistApiController(_repository.Object)
            {
                Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/api/Playlists") }
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
        public void Update_Should_Update_A_Playlist()
        {
            _repository
                 .Setup(it => it.Update(It.IsAny<Int32>(), It.IsAny<String>()))
                 .Callback<Int32, String>((playlistId, name) =>
                 {
                     var tPlaylist = _repositoryList.Find(x => x.PlaylistId == playlistId);
                     tPlaylist.Name = name;
                 });
            var tempPlaylist = _repositoryList.Find(x => x.PlaylistId == 1);
            var testPlaylist = new Playlist
            {
                PlaylistId = tempPlaylist.PlaylistId,
                Name = tempPlaylist.Name
            };

            testPlaylist.Name = "newValue"; 
            _target.Update(testPlaylist);
            
        }

        [TestMethod()]
        public void Insert_Should_Insert_A_Playlist()
        {
            _repository
                 .Setup(it => it.Insert(It.IsAny<Int32>(), It.IsAny<String>()))
                 .Returns<Int32, String>((playlistId, name) =>
                 {
                     _repositoryList.Add(new Playlist(playlistId, name));
                     return playlistId;
                 });

            _target.Insert(new Playlist(11, "name"));
            Assert.AreEqual(11, _repositoryList.Count());
          
        }

        [TestMethod()]
        public void Delete_Should_Delete_A_Playlist()
        {
            _repository
                 .Setup(it => it.Delete(It.IsAny<Int32>()))
                 .Callback<Int32>((playlistId) =>
                 {
                     var i = _repositoryList.FindIndex(q => q.PlaylistId == playlistId);
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
            PagedResult<Playlist> expectedResult;

            _repository
                 .Setup(it => it.GetDataPageable(It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<String, Int32, Int32>((sortExpression, page, pageSize) =>
                 {
                     var query = _repositoryList;
                     switch (sortExpression)
                     {
                         case "PlaylistId":
                             query = new List<Playlist>(query.OrderBy(q => q.PlaylistId));
                             break;
                         case "Name":
                             query = new List<Playlist>(query.OrderBy(q => q.Name));
                             break;
                     }
                     return query.Take(pageSize).Skip((page - 1) * pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetRowCount())
                 .Returns(_repositoryList.Count);

            var result = _target.GetDataPageable("PlaylistId", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.PlaylistId).FirstOrDefault().PlaylistId, expectedResult.Results.FirstOrDefault().PlaylistId);
        }

        [TestMethod()]
        public void GetDataByPlaylistIdTest()
        {
            _repository
                 .Setup(it => it.GetDataByPlaylistId(It.IsAny<Int32>()))
                     .Returns<Int32>((playlistId) =>
                     {
                         return _repositoryList.Where(x => x.PlaylistId == playlistId).ToList();
                     });

            var result = _target.GetDataByPlaylistId(1).ToList();
            Assert.AreEqual(_repositoryList.Where(x => x.PlaylistId == 1).ToList().Count, result.Count);
        }

        [TestMethod()]
        public void GetPlaylistsByTrackIdTest()
        {
            //_repository
            //     .Setup(it => it.GetPlaylistsByTrackId(It.IsAny<Int32>()))
            //         .Returns<Int32>((trackId) =>
            //         {
            //             return _repositoryList.Where(x => x.TrackId == trackId).ToList();
            //         });

            //var result = _target.GetPlaylistsByTrackId(trackIdValue).ToList();
            //Assert.AreEqual(_repositoryList.Where(x => x.TrackId == trackIdValue).ToList().Count, result.Count);
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPlaylistsByTrackIdPageableTest()
        {
            PagedResult<Playlist> expectedResult;

            _repository
                 .Setup(it => it.GetPlaylistsByTrackIdPageable(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<Int32, String, Int32, Int32>((trackId, sortExpression, page, pageSize) =>
                 {
                     var query = _repositoryList;
                     switch (sortExpression)
                     {
                         case "PlaylistId":
                             query = new List<Playlist>(query.OrderBy(q => q.PlaylistId));
                             break;
                         case "Name":
                             query = new List<Playlist>(query.OrderBy(q => q.Name));
                             break;
                     }
                     return query.Take(pageSize).Skip((page - 1) * pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetPlaylistsByTrackIdRowCount(1))
                 .Returns(_repositoryList.Count);

            var result = _target.GetPlaylistsByTrackIdPageable(1, "PlaylistId", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.PlaylistId).FirstOrDefault().PlaylistId, expectedResult.Results.FirstOrDefault().PlaylistId);
        }


    }
}
