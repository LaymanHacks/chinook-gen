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


        [HttpGet]
        public IQueryable<Track> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }


        [HttpPut]
        public void Update(Int32 trackId, String name, int albumId, Int32 mediaTypeId, int genreId, String composer, Int32 milliseconds, int bytes, Decimal unitPrice)
        {
            _dbRepository.Update(trackId, name, albumId, mediaTypeId, genreId, composer, milliseconds, bytes, unitPrice);
        }


        [HttpPut]
        public void Update(Track track)
        {
            if (track.AlbumId == null) return;
            if (track.Bytes == null) return;
            if (track.GenreId != null)
                Update(track.TrackId, track.Name, (int) track.AlbumId, track.MediaTypeId, (int) track.GenreId, track.Composer, track.Milliseconds, (int) track.Bytes, track.UnitPrice);
        }


        [HttpPost]
        public Int32 Insert(Int32 trackId, String name, int albumId, Int32 mediaTypeId, int genreId, String composer, Int32 milliseconds, int bytes, Decimal unitPrice)
        {
                return _dbRepository.Insert(trackId, name, (int) albumId, mediaTypeId, genreId, composer, milliseconds, (int) bytes, unitPrice);
        }


        [HttpPost]
        public Int32 Insert(Track track)
        {
            if (track.AlbumId != null)
                if (track.GenreId != null)
                    if (track.Bytes != null)
                        return Insert(track.TrackId, track.Name, (int) track.AlbumId, track.MediaTypeId, (int) track.GenreId, track.Composer, track.Milliseconds, (int) track.Bytes, track.UnitPrice);
            return -1;
        }


        [HttpDelete]
        public void Delete(Int32 trackId)
        {
            _dbRepository.Delete(trackId);
        }


        [HttpDelete]
        public void Delete(Track track)
        {
            Delete(track.TrackId);
        }


        [HttpGet]
        public IQueryable<Track> GetPageable(String sortExpression, Int32 startRowIndex, Int32 maximumRows)
        {
            return _dbRepository.GetPageable(sortExpression, startRowIndex, maximumRows).AsQueryable();
        }


        [HttpGet]
        public Int32 GetRowCount()
        {
            return _dbRepository.GetRowCount();
        }


        [HttpGet]
        public IQueryable<Track> GetDataByTrackId(Int32 trackId)
        {
            return _dbRepository.GetDataByTrackId(trackId).AsQueryable();
        }


        [HttpGet]
        public IQueryable<Track> GetTracksByPlaylistId(Int32 playlistId)
        {
            return _dbRepository.GetTracksByPlaylistId(playlistId).AsQueryable();
        }


        [HttpGet]
        public IQueryable<Track> GetTracksByPlaylistIdPageable(Int32 playlistId, String sortExpression, Int32 startRowIndex, Int32 maximumRows)
        {
            return _dbRepository.GetTracksByPlaylistIdPageable(playlistId, sortExpression, startRowIndex, maximumRows).AsQueryable();
        }


        [HttpGet]
        public Int32 GetTracksByPlaylistIdRowCount(Int32 playlistId)
        {
            return _dbRepository.GetTracksByPlaylistIdRowCount(playlistId);
        }

        [Route("api/album/{albumId}/tracks/all", Name = "GetDataByAlbumIdRoute")]
        [HttpGet]
        public IQueryable<Track> GetDataByAlbumId(Int32 albumId)
        {
            return _dbRepository.GetDataByAlbumId(albumId).AsQueryable();
        }

        [Route("api/album/{albumId}/tracks", Name = "GetDataByAlbumIdRoutePagable")]
        [HttpGet]
        public IQueryable<Track> GetDataByAlbumIdPageable(String sortExpression, Int32 startRowIndex, Int32 maximumRows, Int32 albumId)
        {
            return _dbRepository.GetDataByAlbumIdPageable(sortExpression, startRowIndex, maximumRows, albumId).AsQueryable();
        }


        [HttpGet]
        public Int32 GetDataByAlbumIdRowCount(Int32 albumId)
        {
            return _dbRepository.GetDataByAlbumIdRowCount(albumId);
        }

        [Route("api/genre/{genreId}/tracks/all", Name = "GetDataByGenreIdRoute")]
        [HttpGet]
        public IQueryable<Track> GetDataByGenreId(Int32 genreId)
        {
            return _dbRepository.GetDataByGenreId(genreId).AsQueryable();
        }

         [Route("api/genre/{genreId}/tracks", Name = "GetDataByGenreIdRoutePagable")]
        [HttpGet]
        public IQueryable<Track> GetDataByGenreIdPageable(String sortExpression, Int32 startRowIndex, Int32 maximumRows, Int32 genreId)
        {
            return _dbRepository.GetDataByGenreIdPageable(sortExpression, startRowIndex, maximumRows, genreId).AsQueryable();
        }


        [HttpGet]
        public Int32 GetDataByGenreIdRowCount(Int32 genreId)
        {
            return _dbRepository.GetDataByGenreIdRowCount(genreId);
        }

        [Route("api/mediaType/{mediaTypeId}/tracks/all", Name = "GetDataByMediaTypeIdRoute")]
        [HttpGet]
        public IQueryable<Track> GetDataByMediaTypeId(Int32 mediaTypeId)
        {
            return _dbRepository.GetDataByMediaTypeId(mediaTypeId).AsQueryable();
        }

        [Route("api/mediaType/{mediaTypeId}/tracks", Name = "GetDataByMediaTypeIdRoutePagable")]
        [HttpGet]
        public IQueryable<Track> GetDataByMediaTypeIdPageable(String sortExpression, Int32 startRowIndex, Int32 maximumRows, Int32 mediaTypeId)
        {
            return _dbRepository.GetDataByMediaTypeIdPageable(sortExpression, startRowIndex, maximumRows, mediaTypeId).AsQueryable();
        }


        [HttpGet]
        public Int32 GetDataByMediaTypeIdRowCount(Int32 mediaTypeId)
        {
            return _dbRepository.GetDataByMediaTypeIdRowCount(mediaTypeId);
        }


    }
}
