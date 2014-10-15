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
    public class MediaTypeApiController : ApiController
    {
        private readonly IMediaTypeRepository _dbRepository;

        public MediaTypeApiController(IDbMediaTypeCommandProvider dbCommandProvider)
        {
            _dbRepository = new DbMediaTypeRepository(dbCommandProvider);
        }
   
        [Route("api/mediaTypes/all", Name = "MediaTypesGetDataRoute")]
        [HttpGet]
        public IQueryable<MediaType> GetData() 
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/mediaTypes", Name = "MediaTypesUpdateRoute")]
        [HttpPut]
        public void Update(MediaType mediaType)
        {
            _dbRepository.Update( (Int32)mediaType.MediaTypeId, mediaType.Name);
          }

        [Route("api/mediaTypes", Name = "MediaTypesInsertRoute")]
        [HttpPost]
        public Int32 Insert(MediaType mediaType)
        {
             return _dbRepository.Insert( (Int32)mediaType.MediaTypeId, mediaType.Name);
          }

        [Route("api/mediaTypes", Name = "MediaTypesDeleteRoute")]
        [HttpDelete]
        public HttpResponseMessage Delete(Int32 mediaTypeId) 
        {
            try
            {
                _dbRepository.Delete(mediaTypeId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/mediaTypes", Name = "MediaTypesGetDataPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
              if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetRowCount();
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "MediaTypesGetDataPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/mediaTypes/{mediaTypeId}", Name = "MediaTypesGetDataByMediaTypeIdRoute")]
        [HttpGet]
        public IQueryable<MediaType> GetDataByMediaTypeId(Int32 mediaTypeId) 
        {
            return _dbRepository.GetDataByMediaTypeId(mediaTypeId).AsQueryable();
        }
        
    }
}
