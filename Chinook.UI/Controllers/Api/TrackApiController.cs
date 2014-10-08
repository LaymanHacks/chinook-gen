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
    public class TrackApiController : ApiController
    {
        private readonly ITrackRepository _dbRepository;

        public TrackApiController(IDbTrackCommandProvider dbCommandProvider)
        {
            _dbRepository = new DbTrackRepository(dbCommandProvider);
        }

         [Route("api/tracks/all")]
        [HttpGet]
        public IQueryable<Track> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/tracks", Name = "tracksPagableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataPageable(string sortExpression = "TrackId", Int32 page = 1,
            Int32 pageSize = 10)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);

            var albums = _dbRepository.GetDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetRowCount();

            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "tracksPagableRoute", page, pageSize,
                totalCount, albums);

            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/track/{trackId}", Name = "GetDataByTrackIdRoute")]
        [HttpGet]
        public IQueryable<Track> GetDataByTrackId(Int32 trackId)
        {
            return _dbRepository.GetDataByTrackId(trackId).AsQueryable();
        }

        [Route("api/playlist/{playlistId}/tracks/all", Name = "GetTracksByPlaylistIdRoute")]
        [HttpGet]
        public IQueryable<Track> GetTracksByPlaylistId(Int32 playlistId)
        {
            return _dbRepository.GetTracksByPlaylistId(playlistId).AsQueryable();
        }

        [Route("api/playlist/{playlistId}/tracks", Name = "GetTracksByPlaylistIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetTracksByPlaylistIdPageable(Int32 playlistId, string sortExpression = "TrackId",
            Int32 page = 1, Int32 pageSize = 10)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);

            var tracks = _dbRepository.GetTracksByPlaylistIdPageable(playlistId,sortExpression, (page - 1)*pageSize, pageSize);
            var totalCount = _dbRepository.GetTracksByPlaylistIdRowCount(playlistId);

            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "GetTracksByPlaylistIdPageableRoute", page,
                pageSize, totalCount, tracks);

            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }
        
        [Route("api/album/{albumId}/tracks/all", Name = "GetDataByAlbumIdRoute")]
        [HttpGet]
        public IQueryable<Track> GetDataByAlbumId(Int32 albumId)
        {
            return _dbRepository.GetDataByAlbumId(albumId).AsQueryable();
        }

        [Route("api/album/{albumId}/tracks", Name = "GetTracksByAlbumIdRoutePagable")]
        [HttpGet]
        public HttpResponseMessage GetDataByAlbumIdPageable(Int32 albumId, string sortExpression = "TrackId",
            Int32 page = 1, Int32 pageSize = 10)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);

            var tracks = _dbRepository.GetDataByAlbumIdPageable(albumId,sortExpression, (page - 1)*pageSize, pageSize);
            var totalCount = _dbRepository.GetDataByAlbumIdRowCount(albumId);

            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "GetTracksByAlbumIdRoutePagable", page,
                pageSize, totalCount, tracks);

            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }
        
        [Route("api/genre/{genreId}/tracks/all", Name = "GetDataByGenreIdRoute")]
        [HttpGet]
        public IQueryable<Track> GetDataByGenreId(Int32 genreId)
        {
            return _dbRepository.GetDataByGenreId(genreId).AsQueryable();
        }

        [Route("api/genre/{genreId}/tracks", Name = "GetTracksByGenreIdRoutePagable")]
        [HttpGet]
        public HttpResponseMessage GetDataByGenreIdPageable(Int32 genreId, string sortExpression = "TrackId",
            Int32 page = 1, Int32 pageSize = 10)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);

            var tracks = _dbRepository.GetDataByGenreIdPageable(genreId,sortExpression, (page - 1)*pageSize, pageSize);
            var totalCount = _dbRepository.GetDataByGenreIdRowCount(genreId);

            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "GetTracksByGenreIdRoutePagable", page,
                pageSize, totalCount, tracks);

            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

       [Route("api/mediaType/{mediaTypeId}/tracks/all", Name = "GetTracksByMediaTypeIdRoute")]
        [HttpGet]
        public IQueryable<Track> GetDataByMediaTypeId(Int32 mediaTypeId)
        {
            return _dbRepository.GetDataByMediaTypeId(mediaTypeId).AsQueryable();
        }

        [Route("api/mediaType/{mediaTypeId}/tracks", Name = "GetTracksByMediaTypeIdRoutePagable")]
        [HttpGet]
        public HttpResponseMessage GetDataByMediaTypeIdPageable(Int32 mediaTypeId, string sortExpression = "TrackId",
            Int32 page = 1, Int32 pageSize = 10)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);

            var tracks = _dbRepository.GetDataByMediaTypeIdPageable(mediaTypeId,sortExpression, (page - 1)*pageSize, pageSize);
            var totalCount = _dbRepository.GetDataByMediaTypeIdRowCount(mediaTypeId);

            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "GetTracksByMediaTypeIdRoutePagable", page,
                pageSize, totalCount, tracks);

            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/tracks", Name = "TracksUpdateRoute")]
        [HttpPut]
        public void Update(Track track)
        {
            _dbRepository.Update((Int32)track.TrackId, (string)track.Name, track.AlbumId, (Int32)track.MediaTypeId, track.GenreId, track.Composer, (Int32)track.Milliseconds, track.Bytes, (decimal)track.UnitPrice);
        }

        [Route("api/tracks", Name = "TracksInsertRoute")]
        [HttpPost]
        public Int32 Insert(Track track)
        {
            return _dbRepository.Insert((Int32)track.TrackId, (string)track.Name, track.AlbumId, (Int32)track.MediaTypeId, track.GenreId, track.Composer, (Int32)track.Milliseconds, track.Bytes, (decimal)track.UnitPrice);
        }

         [Route("api/tracks/{trackId:int:min(1)}")]
       [HttpDelete]
        public void Delete(Int32 trackId)
        {
            _dbRepository.Delete(trackId);
        }


       
     }
}
