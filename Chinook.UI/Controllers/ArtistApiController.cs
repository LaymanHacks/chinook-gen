using System;
using System.Linq;
using System.Web.Http;
using Chinook.Data.DbCommandProvider;
using Chinook.Data.Repository;
using Chinook.Domain.Entities;

namespace Chinook.Web.UI.Controllers
{
    public class ArtistApiController : ApiController
    {
        private readonly IArtistRepository _dbRepository;

        public ArtistApiController(IDbArtistCommandProvider dbCommandProvider)
        {
            _dbRepository = new DbArtistRepository(dbCommandProvider);
        }

        [HttpGet]
        public IQueryable<Artist> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
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
        public IQueryable<Artist> GetPagableSubSet(String sortExpression, Int32 startRowIndex, Int32 maximumRows)
        {
            return _dbRepository.GetPagableSubSet(sortExpression, startRowIndex, maximumRows).AsQueryable();
        }

        [HttpGet]
        public Int32 GetRowCount()
        {
            return _dbRepository.GetRowCount();
        }

        [HttpGet]
        public IQueryable<Artist> GetDataByArtistId(Int32 artistId)
        {
            return _dbRepository.GetDataByArtistId(artistId).AsQueryable();
        }
    }
}