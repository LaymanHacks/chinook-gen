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
    public class InvoiceLineApiController : ApiController
    {
        private readonly IInvoiceLineRepository _dbRepository;

        public InvoiceLineApiController(IDbInvoiceLineCommandProvider dbCommandProvider)
        {
            _dbRepository = new DbInvoiceLineRepository(dbCommandProvider);
        }

        [Route("api/invoiceLines/all", Name = "InvoiceLinesGetDataRoute")]
        [HttpGet]
        public IQueryable<InvoiceLine> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/invoiceLines", Name = "InvoiceLinesUpdateRoute")]
        [HttpPut]
        public void Update(InvoiceLine invoiceLine)
        {
            _dbRepository.Update((Int32)invoiceLine.InvoiceLineId, (Int32)invoiceLine.InvoiceId, (Int32)invoiceLine.TrackId, (decimal)invoiceLine.UnitPrice, (Int32)invoiceLine.Quantity);
        }

        [Route("api/invoiceLines", Name = "InvoiceLinesInsertRoute")]
        [HttpPost]
        public Int32 Insert(InvoiceLine invoiceLine)
        {
            return _dbRepository.Insert((Int32)invoiceLine.InvoiceLineId, (Int32)invoiceLine.InvoiceId, (Int32)invoiceLine.TrackId, (decimal)invoiceLine.UnitPrice, (Int32)invoiceLine.Quantity);
        }

        [Route("api/invoiceLines", Name = "InvoiceLinesDeleteRoute")]
        [HttpDelete]
        public HttpResponseMessage Delete(Int32 invoiceLineId)
        {
            try
            {
                _dbRepository.Delete(invoiceLineId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/invoiceLines", Name = "InvoiceLinesGetDataPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataPageable(String sortExpression, Int32 page, Int32 pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetRowCount();
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "InvoiceLinesGetDataPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/invoiceLines/all", Name = "InvoiceLinesGetDataByInvoiceLineIdRoute")]
        [HttpGet]
        public IQueryable<InvoiceLine> GetDataByInvoiceLineId(Int32 invoiceLineId)
        {
            return _dbRepository.GetDataByInvoiceLineId(invoiceLineId).AsQueryable();
        }

        [Route("api/invoices/{invoiceId}/invoiceLines/all", Name = "InvoiceLinesGetDataByInvoiceIdRoute")]
        [HttpGet]
        public IQueryable<InvoiceLine> GetDataByInvoiceId(Int32 invoiceId)
        {
            return _dbRepository.GetDataByInvoiceId(invoiceId).AsQueryable();
        }

        [Route("api/invoices/{invoiceId}/invoiceLines", Name = "InvoiceLinesGetDataByInvoiceIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByInvoiceIdPageable(Int32 invoiceId, String sortExpression, Int32 page, Int32 pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByInvoiceIdPageable(invoiceId, sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetDataByInvoiceIdRowCount(invoiceId);
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "InvoiceLinesGetDataByInvoiceIdPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/tracks/{trackId}/invoiceLines/all", Name = "InvoiceLinesGetDataByTrackIdRoute")]
        [HttpGet]
        public IQueryable<InvoiceLine> GetDataByTrackId(Int32 trackId)
        {
            return _dbRepository.GetDataByTrackId(trackId).AsQueryable();
        }

        [Route("api/tracks/{trackId}/invoiceLines", Name = "InvoiceLinesGetDataByTrackIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByTrackIdPageable(Int32 trackId, String sortExpression, Int32 page, Int32 pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByTrackIdPageable(trackId, sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetDataByTrackIdRowCount(trackId);
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "InvoiceLinesGetDataByTrackIdPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }


    }
}
