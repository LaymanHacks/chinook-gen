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
        public HttpResponseMessage GetPageable(string sortExpression = "ArtistId", Int32 page = 1,
            Int32 pageSize = 10)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);

            var albums = _dbRepository.GetPageable(sortExpression, (page - 1) * pageSize, pageSize);
            var totalCount = _dbRepository.GetRowCount();

            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "ArtistsPagableRoute", page, pageSize,
                totalCount, albums);

            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [HttpPut]
        public void Update(Int32 artistId, String name)
        {
            _dbRepository.Update(artistId, name);
        }

        [HttpPost]
        public Int32 Insert(Int32 artistId, String name)
        {
            return _dbRepository.Insert(artistId, name);
        }

        [HttpDelete]
        public void Delete(Int32 artistId)
        {
            _dbRepository.Delete(artistId);
        }


        [HttpGet]
        public IQueryable<Artist> GetDataByArtistId(Int32 artistId)
        {
            return _dbRepository.GetDataByArtistId(artistId).AsQueryable();
        }
    }
}