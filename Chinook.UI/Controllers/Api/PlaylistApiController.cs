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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chinook.Data.DbCommandProvider;
using Chinook.Data.Repository;
using Chinook.Domain.Entities;

namespace Chinook.Web.UI.Controllers.Api
{
    public class PlaylistApiController : ApiController
    {
        private readonly IPlaylistRepository _dbRepository;

        public PlaylistApiController(IPlaylistRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        [Route("api/playlists/all", Name = "PlaylistsGetDataRoute")]
        [HttpGet]
        public IQueryable<Playlist> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/playlists", Name = "PlaylistsUpdateRoute")]
        [HttpPut]
        public void Update(Playlist playlist)
        {
            _dbRepository.Update((Int32)playlist.PlaylistId, playlist.Name);
        }

        [Route("api/playlists", Name = "PlaylistsInsertRoute")]
        [HttpPost]
        public Int32 Insert(Playlist playlist)
        {
            return _dbRepository.Insert((Int32)playlist.PlaylistId, playlist.Name);
        }

        [Route("api/playlists", Name = "PlaylistsDeleteRoute")]
        [HttpDelete]
        public HttpResponseMessage Delete(Int32 playlistId)
        {
            try
            {
                _dbRepository.Delete(playlistId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/playlists", Name = "PlaylistsGetDataPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataPageable(String sortExpression, Int32 page, Int32 pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetRowCount();
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "PlaylistsGetDataPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/playlists", Name = "PlaylistsGetDataByPlaylistIdRoute")]
        [HttpGet]
        public IQueryable<Playlist> GetDataByPlaylistId(Int32 playlistId)
        {
            return _dbRepository.GetDataByPlaylistId(playlistId).AsQueryable();
        }

        [Route("api/tracks/{trackId}/playlists/all", Name = "PlaylistsGetPlaylistsByTrackIdRoute")]
        [HttpGet]
        public IQueryable<Playlist> GetPlaylistsByTrackId(Int32 trackId)
        {
            return _dbRepository.GetPlaylistsByTrackId(trackId).AsQueryable();
        }

        [Route("api/tracks/{trackId}/playlists", Name = "PlaylistsGetPlaylistsByTrackIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetPlaylistsByTrackIdPageable(Int32 trackId, String sortExpression, Int32 page, Int32 pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetPlaylistsByTrackIdPageable(trackId, sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetPlaylistsByTrackIdRowCount(trackId);
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "PlaylistsGetPlaylistsByTrackIdPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }


    }
}
