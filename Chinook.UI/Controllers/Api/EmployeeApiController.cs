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
    public class EmployeeApiController : ApiController
    {
        private readonly IEmployeeRepository _dbRepository;

        public EmployeeApiController(IDbEmployeeCommandProvider dbCommandProvider)
        {
            _dbRepository = new DbEmployeeRepository(dbCommandProvider);
        }

        [HttpGet]
        public IQueryable<Employee> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [HttpPut]
        public void Update(Int32 employeeId, String lastName, String firstName, String title, int? reportsTo, DateTime? birthDate, DateTime? hireDate, String address, String city, String state, String country, String postalCode, String phone, String fax, String email)
        {
            _dbRepository.Update(employeeId, lastName, firstName, title, reportsTo, birthDate, hireDate, address, city, state, country, postalCode, phone, fax, email);
        }


        [HttpPut]
        public void Update(Employee employee)
        {
            Update(employee.EmployeeId, employee.LastName, employee.FirstName, employee.Title, employee.ReportsTo, employee.BirthDate, employee.HireDate, employee.Address, employee.City, employee.State, employee.Country, employee.PostalCode, employee.Phone, employee.Fax, employee.Email);
        }

        [HttpPost]
        public Int32 Insert(Int32 employeeId, String lastName, String firstName, String title, int? reportsTo, DateTime? birthDate, DateTime? hireDate, String address, String city, String state, String country, String postalCode, String phone, String fax, String email)
        {
            return _dbRepository.Insert(employeeId, lastName, firstName, title, reportsTo, birthDate, hireDate, address, city, state, country, postalCode, phone, fax, email);
        }


        [HttpPost]
        public Int32 Insert(Employee employee)
        {
            return Insert(employee.EmployeeId, employee.LastName, employee.FirstName, employee.Title, employee.ReportsTo, employee.BirthDate, employee.HireDate, employee.Address, employee.City, employee.State, employee.Country, employee.PostalCode, employee.Phone, employee.Fax, employee.Email);
        }

        [HttpDelete]
        public void Delete(Int32 employeeId)
        {
            _dbRepository.Delete(employeeId);
        }


        [HttpDelete]
        public void Delete(Employee employee)
        {
            Delete(employee.EmployeeId);
        }

        [HttpGet]
        public HttpResponseMessage GetDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
              if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetRowCount();
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "GetDataPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/employees/{reportsTo}", Name = "GetDataByEmployeeIdRoute")]
        [HttpGet]
        public IQueryable<Employee> GetDataByEmployeeId(Int32 employeeId)
        {
            return _dbRepository.GetDataByEmployeeId(employeeId).AsQueryable();
        }

        [Route("api/employees/{reportsTo}", Name = "GetDataByReportsToRoute")]
        [HttpGet]
        public IQueryable<Employee> GetDataByReportsTo(Int32 reportsTo)
        {
            return _dbRepository.GetDataByReportsTo(reportsTo).AsQueryable();
        }

        [Route("api/employees/{reportsTo}/all", Name = "GetDataByReportsToPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByReportsToPageable(Int32 reportsTo, String sortExpression, Int32 page, Int32 pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByReportsToPageable(reportsTo, sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetDataByReportsToRowCount(reportsTo);
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "GetDataByReportsToPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }


    }
}