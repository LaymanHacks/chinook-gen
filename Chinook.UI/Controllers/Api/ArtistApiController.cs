using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chinook.Data.Repository;
using Chinook.Domain.Entities;

namespace Chinook.Web.UI.Controllers.APi
{
    public class ArtistApiController : ApiController
    {
        private readonly IArtistRepository _dbRepository;

        public ArtistApiController(IArtistRepository artistRepository)
        {
            _dbRepository = artistRepository;
        }

        [Route("api/artists/all")]
        [HttpGet]
        public IQueryable<Artist> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/artists", Name = "ArtistsPagableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataPageable(string sortExpression = "ArtistId", Int32 page = 1,
            Int32 pageSize = 10)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);

            var albums = _dbRepository.GetDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetRowCount();

            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "ArtistsPagableRoute", page, pageSize,
                totalCount, albums);

            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/artists", Name = "ArtistsUpdateRoute")]
        [HttpPut]
        public void Update(Artist artist)
        {
            _dbRepository.Update((Int32)artist.ArtistId, artist.Name);
        }

        [Route("api/artists", Name = "ArtistsInsertRoute")]
        [HttpPost]
        public Int32 Insert(Artist artist)
        {
            return _dbRepository.Insert((Int32)artist.ArtistId, artist.Name);
        }

         [Route("api/artists/{artistid:int:min(1)}")]
        [HttpDelete]
        public HttpResponseMessage Delete(Int32 artistId)
        {
            try
            {
                _dbRepository.Delete(artistId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

         [Route("api/artists/{artistid:int:min(1)}")]
        [HttpGet]
        public IQueryable<Artist> GetDataByArtistId(Int32 artistId)
        {
            return _dbRepository.GetDataByArtistId(artistId).AsQueryable();
        }
    }
}