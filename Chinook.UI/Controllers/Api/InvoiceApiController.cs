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
    public class InvoiceApiController : ApiController
    {
        private readonly IInvoiceRepository _dbRepository;

        public InvoiceApiController(IDbInvoiceCommandProvider dbCommandProvider)
        {
            _dbRepository = new DbInvoiceRepository(dbCommandProvider);
        }

        [Route("api/invoices/all", Name = "InvoicesGetDataRoute")]
        [HttpGet]
        public IQueryable<Invoice> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/invoices", Name = "InvoicesUpdateRoute")]
        [HttpPut]
        public void Update(Invoice invoice)
        {
            _dbRepository.Update((Int32)invoice.InvoiceId, (Int32)invoice.CustomerId, (DateTime)invoice.InvoiceDate, invoice.BillingAddress, invoice.BillingCity, invoice.BillingState, invoice.BillingCountry, invoice.BillingPostalCode, (decimal)invoice.Total);
        }

        [Route("api/invoices", Name = "InvoicesInsertRoute")]
        [HttpPost]
        public Int32 Insert(Invoice invoice)
        {
            return _dbRepository.Insert((Int32)invoice.InvoiceId, (Int32)invoice.CustomerId, (DateTime)invoice.InvoiceDate, invoice.BillingAddress, invoice.BillingCity, invoice.BillingState, invoice.BillingCountry, invoice.BillingPostalCode, (decimal)invoice.Total);
        }

        [Route("api/invoices", Name = "InvoicesDeleteRoute")]
        [HttpDelete]
        public void Delete(Int32 invoiceId)
        {
            _dbRepository.Delete(invoiceId);
        }

        [Route("api/invoices", Name = "InvoicesGetDataPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataPageable(String sortExpression, Int32 page, Int32 pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetRowCount();
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "InvoicesGetDataPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/invoices/{invoiceId:int}", Name = "InvoicesGetDataByInvoiceIdRoute")]
        [HttpGet]
        public IQueryable<Invoice> GetDataByInvoiceId(Int32 invoiceId)
        {
            return _dbRepository.GetDataByInvoiceId(invoiceId).AsQueryable();
        }

        [Route("api/customers/{customerId}/invoices/all", Name = "InvoicesGetDataByCustomerIdRoute")]
        [HttpGet]
        public IQueryable<Invoice> GetDataByCustomerId(Int32 customerId)
        {
            return _dbRepository.GetDataByCustomerId(customerId).AsQueryable();
        }

        [Route("api/customers/{customerId}/invoices", Name = "InvoicesGetDataByCustomerIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByCustomerIdPageable(Int32 customerId, String sortExpression, Int32 page, Int32 pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByCustomerIdPageable(customerId, sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetDataByCustomerIdRowCount(customerId);
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "InvoicesGetDataByCustomerIdPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }


    }
}
