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
using Chinook.Data.DbCommandProvider;
using Chinook.Data.Repository;
using Chinook.Domain.Entities;

namespace Chinook.Web.UI.Controllers.Api
{
    public class PlaylistTrackApiController : ApiController
    {
        private readonly IPlaylistTrackRepository _dbRepository;

        public PlaylistTrackApiController(IDbPlaylistTrackCommandProvider dbCommandProvider)
        {
            _dbRepository = new DbPlaylistTrackRepository(dbCommandProvider);
        }

        [Route("api/playlistTracks/all", Name = "PlaylistTracksGetDataRoute")]
        [HttpGet]
        public IQueryable<PlaylistTrack> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/playlistTracks", Name = "PlaylistTracksUpdateRoute")]
        [HttpPut]
        public void Update(PlaylistTrack playlistTrack)
        {
            _dbRepository.Update((Int32)playlistTrack.PlaylistId, (Int32)playlistTrack.TrackId);
        }

        [Route("api/playlistTracks", Name = "PlaylistTracksInsertRoute")]
        [HttpPost]
        public ICollection<PlaylistTrack> Insert(PlaylistTrack playlistTrack)
        {
            return _dbRepository.Insert((Int32)playlistTrack.PlaylistId, (Int32)playlistTrack.TrackId);
        }

        [Route("api/playlistTracks", Name = "PlaylistTracksDeleteRoute")]
        [HttpDelete]
        public void Delete(Int32 playlistId, Int32 trackId)
        {
            _dbRepository.Delete(playlistId, trackId);
        }

        [Route("api/playlistTracks", Name = "PlaylistTracksGetDataPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataPageable(String sortExpression, Int32 page, Int32 pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetRowCount();
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "PlaylistTracksGetDataPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/playlistTracks/all", Name = "PlaylistTracksGetDataByPlaylistIdTrackIdRoute")]
        [HttpGet]
        public IQueryable<PlaylistTrack> GetDataByPlaylistIdTrackId(Int32 playlistId, Int32 trackId)
        {
            return _dbRepository.GetDataByPlaylistIdTrackId(playlistId, trackId).AsQueryable();
        }

        [Route("api/playlists/{playlistId}/playlistTracks/all", Name = "PlaylistTracksGetDataByPlaylistIdRoute")]
        [HttpGet]
        public IQueryable<PlaylistTrack> GetDataByPlaylistId(Int32 playlistId)
        {
            return _dbRepository.GetDataByPlaylistId(playlistId).AsQueryable();
        }

        [Route("api/playlists/{playlistId}/playlistTracks", Name = "PlaylistTracksGetDataByPlaylistIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByPlaylistIdPageable(Int32 playlistId, String sortExpression, Int32 page, Int32 pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByPlaylistIdPageable(playlistId, sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetDataByPlaylistIdRowCount(playlistId);
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "PlaylistTracksGetDataByPlaylistIdPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/tracks/{trackId}/playlistTracks/all", Name = "PlaylistTracksGetDataByTrackIdRoute")]
        [HttpGet]
        public IQueryable<PlaylistTrack> GetDataByTrackId(Int32 trackId)
        {
            return _dbRepository.GetDataByTrackId(trackId).AsQueryable();
        }

        [Route("api/tracks/{trackId}/playlistTracks", Name = "PlaylistTracksGetDataByTrackIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByTrackIdPageable(Int32 trackId, String sortExpression, Int32 page, Int32 pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByTrackIdPageable(trackId, sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetDataByTrackIdRowCount(trackId);
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "PlaylistTracksGetDataByTrackIdPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }


    }
}