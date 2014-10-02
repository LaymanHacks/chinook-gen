using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chinook.Data.Repository;
using Chinook.Domain.Entities;

namespace Chinook.Web.UI.Controllers.Api
{
    public class AlbumApiController : ApiController
    {
        private readonly IAlbumRepository _dbRepository;

        public AlbumApiController(IAlbumRepository albumRepository)
        {
            _dbRepository =  albumRepository;
        }

        [Route("api/albums/all")]
        [HttpGet]
        public IQueryable<Album> GetAlbums()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/albums", Name = "AlbumsPagableRoute")]
        public HttpResponseMessage GetAlbumsPagable(string sortExpression = "AlbumId", Int32 page = 1,
            Int32 pageSize = 10)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);

            var albums = _dbRepository.GetPagableSubSet(sortExpression, (page - 1)*pageSize, pageSize);
            var totalCount = _dbRepository.GetRowCount();

            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "AlbumsPagableRoute", page, pageSize,
                totalCount, albums);

            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/albums/{albumId:int:min(1)}")]
        [HttpGet]
        public Album GetDataByAlbumId(Int32 albumId)
        {
            return _dbRepository.GetDataByAlbumId(albumId).FirstOrDefault();
        }

        [Route("api/artist/{artistId}/albums/all")]
        [HttpGet]
        public IQueryable<Album> GetDataByArtistId(Int32 artistId)
        {
            return _dbRepository.GetDataByArtistId(artistId).AsQueryable();
        }

        [Route("api/artist/{artistId}/albums", Name = "AlbumsByArtistIdPagableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByArtistIdPagableSubSet(Int32 artistId, string sortExpression = "ArtistId",
            Int32 page = 1, Int32 pageSize = 10)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);

            var albums = _dbRepository.GetDataByArtistIdPagableSubSet(sortExpression, (page - 1)*pageSize, pageSize,
                artistId);
            var totalCount = _dbRepository.GetDataByArtistIdRowCount(artistId);

            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "AlbumsByArtistIdPagableRoute", page,
                pageSize, totalCount, albums);

            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [HttpPut]
        public void Update(Int32 albumId, string title, Int32 artistId)
        {
            _dbRepository.Update(albumId, title, artistId);
        }

         [HttpPut]
   public void Update(Album album )
         {
          
             Update(album.AlbumId, album.Title, album.ArtistId);
       
    }

        [HttpPost]
        public Int32 Insert(Int32 albumId, string title, Int32 artistId)
        {
            return _dbRepository.Insert(albumId, title, artistId);
        }

        [HttpDelete]
        public void Delete(Int32 albumId)
        {
            _dbRepository.Delete(albumId);
        }
    }
}