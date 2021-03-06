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
using Chinook.Web;

namespace Chinook.UI.Web.Controllers.Api
{
    public class GenreApiController : ApiController
    {
        private readonly IGenreRepository _dbRepository;

        public GenreApiController(IGenreRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        [Route("api/genres/all", Name = "GenresGetDataRoute")]
        [HttpGet]
        public IQueryable<Genre> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/genres", Name = "GenresUpdateRoute")]
        [HttpPut]
        public void Update(Genre genre)
        {
            _dbRepository.Update((Int32)genre.GenreId, genre.Name);
        }

        [Route("api/genres", Name = "GenresInsertRoute")]
        [HttpPost]
        public Int32 Insert(Genre genre)
        {
            return _dbRepository.Insert((Int32)genre.GenreId, genre.Name);
        }

        [Route("api/genres", Name = "GenresDeleteRoute")]
        [HttpDelete]
        public HttpResponseMessage Delete(Int32 genreId)
        {
            try
            {
                _dbRepository.Delete(genreId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/genres", Name = "GenresGetDataPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataPageable(String sortExpression, Int32 page, Int32 pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetRowCount();
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "GenresGetDataPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/genres/{genreId:int}", Name = "GenresGetDataByGenreIdRoute")]
        [HttpGet]
        public IQueryable<Genre> GetDataByGenreId(Int32 genreId)
        {
            return _dbRepository.GetDataByGenreId(genreId).AsQueryable();
        }


    }
}
