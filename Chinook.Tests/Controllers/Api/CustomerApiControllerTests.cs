using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chinook.Data.Repository;
using Chinook.Domain.Entities;
using Chinook.Web.UI.Controllers.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Chinook.Web.UI.Tests.Controllers.Api
{
    [TestClass()]
    public class CustomerApiControllerTests
    {
        private Mock<ICustomerRepository> _repository;
            
        private List<Customer> _repositoryList = new List<Customer>
        {
            new Customer(1,"Luís","Gonçalves","Embraer - Empresa Brasileira de Aeronáutica S.A.","Av. Brigadeiro Faria Lima, 2170","São José dos Campos","SP","Brazil","12227-000","+55 (12) 3923-5555","+55 (12) 3923-5566","luisg@embraer.com.br",3),
            new Customer(2,"Leonie","Köhler","NULL","Theodor-Heuss-Straße 34","Stuttgart","NULL","Germany","70174","+49 0711 2842222","NULL","leonekohler@surfeu.de",5),
            new Customer(3,"François","Tremblay","NULL","1498 rue Bélanger","Montréal","QC","Canada","H2G 1A7","+1 (514) 721-4711","NULL","ftremblay@gmail.com",3),
            new Customer(4,"Bjørn","Hansen","NULL","Ullevålsveien 14","Oslo","NULL","Norway","171","+47 22 44 22 22","NULL","bjorn.hansen@yahoo.no",4),
            new Customer(5,"František","Wichterlová","JetBrains s.r.o.","Klanova 9/506","Prague","NULL","Czech Republic","14700","+420 2 4172 5555","+420 2 4172 5555","frantisekw@jetbrains.com",4),
            new Customer(6,"Helena","Holý","NULL","Rilská 3174/6","Prague","NULL","Czech Republic","14300","+420 2 4177 0449","NULL","hholy@gmail.com",5),
            new Customer(7,"Astrid","Gruber","NULL","Rotenturmstraße 4, 1010 Innere Stadt","Vienne","NULL","Austria","1010","+43 01 5134505","NULL","astrid.gruber@apple.at",5),
            new Customer(8,"Daan","Peeters","NULL","Grétrystraat 63","Brussels","NULL","Belgium","1000","+32 02 219 03 03","NULL","daan_peeters@apple.be",4),
            new Customer(9,"Kara","Nielsen","NULL","Sønder Boulevard 51","Copenhagen","NULL","Denmark","1720","+453 3331 9991","NULL","kara.nielsen@jubii.dk",4),
            new Customer(10,"Eduardo","Martins","Woodstock Discos","Rua Dr. Falcão Filho, 155","São Paulo","SP","Brazil","01007-010","+55 (11) 3033-5446","+55 (11) 3033-4564","eduardo@woodstock.com.br",4)
        };

        private CustomerApiController _target;

        [TestInitialize]
        public void Init()
        {
            _repository = new Mock<ICustomerRepository>();
            _target = new CustomerApiController(_repository.Object)
            {
                Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/api/Customers") }
            };

            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();

            _target.Request.SetConfiguration(config);
        }

        [TestMethod()]
        public void GetDataTest()
        {
            _repository
               .Setup(it => it.GetData())
               .Returns(_repositoryList);

            var result = _target.GetData().ToList();
            Assert.AreEqual(_repositoryList.Count, result.Count);
        }


        [TestMethod()]
        public void Delete_Should_Delete_A_Customer()
        {
            _repository
                .Setup(it => it.Delete(It.IsAny<Int32>()))
                .Callback<Int32>((customerId) =>
                {
                    var i = _repositoryList.FindIndex(q => q.CustomerId == customerId);
                    _repositoryList.RemoveAt(i);
                });


            var iniCount = _repositoryList.Count();
            HttpResponseMessage result = _target.Delete(1);
            Assert.AreEqual(iniCount - 1, _repositoryList.Count());
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }


        [TestMethod()]
        public void Update_Should_Update_An_Customer()
        {
            _repository
                 .Setup(it => it.Update(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<Int32>()))
                 .Callback<Int32, String, String, String, String, String, String, String, String, String, String, String, Int32>((customerId, firstName, lastName, company, address, city, state, country, postalCode, phone, fax, email, supportRepId) =>
                 {
                     var tCustomer = _repositoryList.Find(x => x.CustomerId == customerId);
                     tCustomer.FirstName = firstName;
                     tCustomer.LastName = lastName;
                     tCustomer.Company = company;
                     tCustomer.Address = address;
                     tCustomer.City = city;
                     tCustomer.State = state;
                     tCustomer.Country = country;
                     tCustomer.PostalCode = postalCode;
                     tCustomer.Phone = phone;
                     tCustomer.Fax = fax;
                     tCustomer.Email = email;
                     tCustomer.SupportRepId = supportRepId;
                 });
            var tempCustomer = _repositoryList.Find(x => x.CustomerId == 1);
            var testCustomer = new Customer
            {
                CustomerId = tempCustomer.CustomerId,
                FirstName = tempCustomer.FirstName,
                LastName = tempCustomer.LastName,
                Company = tempCustomer.Company,
                Address = tempCustomer.Address,
                City = tempCustomer.City,
                State = tempCustomer.State,
                Country = tempCustomer.Country,
                PostalCode = tempCustomer.PostalCode,
                Phone = tempCustomer.Phone,
                Fax = tempCustomer.Fax,
                Email = tempCustomer.Email,
                SupportRepId = tempCustomer.SupportRepId
            };

            //TODO change something on testCustomer           
            //testCustomer.oldValue = newValue; 
            _target.Update(testCustomer);
            //Assert.AreEqual(newValue, _repositoryList.Find(x => ).oldValue);
            //TODO fail until we update the test above
            Assert.Fail();
        }

        [TestMethod()]
        public void Insert_Should_Insert_An_Customer()
        {
            _repository
                 .Setup(it => it.Insert(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), It.IsAny<Int32>()))
                 .Returns<Int32, String, String, String, String, String, String, String, String, String, String, String, Int32>((customerId, firstName, lastName, company, address, city, state, country, postalCode, phone, fax, email, supportRepId) =>
                 {
                     var tCustomer = _repositoryList.Find(x => x.CustomerId == customerId);
                     tCustomer.FirstName = firstName;
                     tCustomer.LastName = lastName;
                     tCustomer.Company = company;
                     tCustomer.Address = address;
                     tCustomer.City = city;
                     tCustomer.State = state;
                     tCustomer.Country = country;
                     tCustomer.PostalCode = postalCode;
                     tCustomer.Phone = phone;
                     tCustomer.Fax = fax;
                     tCustomer.Email = email;
                     tCustomer.SupportRepId = supportRepId;

                     return customerId;

                 });
            var tempCustomer = _repositoryList.Find(x => x.CustomerId == 1);
            var testCustomer = new Customer
            {
                CustomerId = tempCustomer.CustomerId,
                FirstName = tempCustomer.FirstName,
                LastName = tempCustomer.LastName,
                Company = tempCustomer.Company,
                Address = tempCustomer.Address,
                City = tempCustomer.City,
                State = tempCustomer.State,
                Country = tempCustomer.Country,
                PostalCode = tempCustomer.PostalCode,
                Phone = tempCustomer.Phone,
                Fax = tempCustomer.Fax,
                Email = tempCustomer.Email,
                SupportRepId = tempCustomer.SupportRepId
            };

            //TODO change something on testCustomer           
            //testCustomer.oldValue = newValue; 
            _target.Update(testCustomer);
            //Assert.AreEqual(newValue, _repositoryList.Find(x => ).oldValue);
            //TODO fail until we update the test above
            Assert.Fail();
        }



        [TestMethod()]
        public void GetDataPageableTest()
        {
            PagedResult<Customer> expectedResult;

            _repository
                 .Setup(it => it.GetDataPageable(It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<String, Int32, Int32>((sortExpression, page, pageSize) =>
                 {
                     var query = _repositoryList;
                     switch (sortExpression)
                     {
                         case "CustomerId":
                             query = new List<Customer>(query.OrderBy(q => q.CustomerId));
                             break;
                         case "FirstName":
                             query = new List<Customer>(query.OrderBy(q => q.FirstName));
                             break;
                         case "LastName":
                             query = new List<Customer>(query.OrderBy(q => q.LastName));
                             break;
                         case "Company":
                             query = new List<Customer>(query.OrderBy(q => q.Company));
                             break;
                         case "Address":
                             query = new List<Customer>(query.OrderBy(q => q.Address));
                             break;
                         case "City":
                             query = new List<Customer>(query.OrderBy(q => q.City));
                             break;
                         case "State":
                             query = new List<Customer>(query.OrderBy(q => q.State));
                             break;
                         case "Country":
                             query = new List<Customer>(query.OrderBy(q => q.Country));
                             break;
                         case "PostalCode":
                             query = new List<Customer>(query.OrderBy(q => q.PostalCode));
                             break;
                         case "Phone":
                             query = new List<Customer>(query.OrderBy(q => q.Phone));
                             break;
                         case "Fax":
                             query = new List<Customer>(query.OrderBy(q => q.Fax));
                             break;
                         case "Email":
                             query = new List<Customer>(query.OrderBy(q => q.Email));
                             break;
                         case "SupportRepId":
                             query = new List<Customer>(query.OrderBy(q => q.SupportRepId));
                             break;
                     }
                     return query.Take(pageSize).Skip((page - 1) * pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetRowCount())
                 .Returns(_repositoryList.Count);

            var result = _target.GetDataPageable("CustomerId", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.CustomerId).FirstOrDefault().CustomerId, expectedResult.Results.FirstOrDefault().CustomerId);
            Assert.AreEqual(_repositoryList.ToList().Count, expectedResult.TotalCount);
        }

        [TestMethod()]
        public void GetDataByCustomerIdTest() 
        {
            _repository
                 .Setup(it => it.GetDataByCustomerId(It.IsAny<Int32>()))
                     .Returns<Int32>((customerId) => 
                 { 
                      return _repositoryList.Where(x => x.CustomerId==customerId).ToList();
                 });
                
            var result = _target.GetDataByCustomerId(1).ToList();
            Assert.AreEqual(_repositoryList.Where(x => x.CustomerId == 1).Count, result.Count);
        }

        [TestMethod()]
        public void GetDataBySupportRepIdTest() 
        {
            _repository
                 .Setup(it => it.GetDataBySupportRepId(It.IsAny<Int32>()))
                     .Returns<Int32>((supportRepId) => _repositoryList.Where(x => x.SupportRepId==supportRepId).ToList());
                
            var result = _target.GetDataBySupportRepId(1).ToList();
             Assert.AreEqual(_repositoryList.Count, result.Count);
        }

        [TestMethod()]
        public void GetDataBySupportRepIdPageableTest()
        {
            PagedResult<Customer> expectedResult;

            _repository
                 .Setup(it => it.GetDataBySupportRepIdPageable(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<Int32, String, Int32, Int32>((supportRepId, sortExpression, page, pageSize) => 
                 { 
                      var query = _repositoryList;
                      switch (sortExpression)
                      {
                          case  "CustomerId":
                              query = new List<Customer>(query.OrderBy(q => q.CustomerId));
                              break;
                          case  "FirstName":
                              query = new List<Customer>(query.OrderBy(q => q.FirstName));
                              break;
                          case  "LastName":
                              query = new List<Customer>(query.OrderBy(q => q.LastName));
                              break;
                          case  "Company":
                              query = new List<Customer>(query.OrderBy(q => q.Company));
                              break;
                          case  "Address":
                              query = new List<Customer>(query.OrderBy(q => q.Address));
                              break;
                          case  "City":
                              query = new List<Customer>(query.OrderBy(q => q.City));
                              break;
                          case  "State":
                              query = new List<Customer>(query.OrderBy(q => q.State));
                              break;
                          case  "Country":
                              query = new List<Customer>(query.OrderBy(q => q.Country));
                              break;
                          case  "PostalCode":
                              query = new List<Customer>(query.OrderBy(q => q.PostalCode));
                              break;
                          case  "Phone":
                              query = new List<Customer>(query.OrderBy(q => q.Phone));
                              break;
                          case  "Fax":
                              query = new List<Customer>(query.OrderBy(q => q.Fax));
                              break;
                          case  "Email":
                              query = new List<Customer>(query.OrderBy(q => q.Email));
                              break;
                          case  "SupportRepId":
                              query = new List<Customer>(query.OrderBy(q => q.SupportRepId));
                              break;                      }
                      return query.Take(pageSize).Skip((page-1)*pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetRowCount())
                 .Returns(_repositoryList.Count);

            var result = _target.GetDataPageable("CustomerId", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.CustomerId).FirstOrDefault().CustomerId, expectedResult.Results.FirstOrDefault().CustomerId);
            Assert.AreEqual(_repositoryList.ToList().Count, expectedResult.TotalCount);
        }
    }
}
