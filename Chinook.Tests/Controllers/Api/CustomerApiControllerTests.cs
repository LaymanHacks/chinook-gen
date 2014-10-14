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
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDataPageableSubSetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDataByCustomerIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDataBySupportRepIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDataBySupportRepIdPageableSubSetTest()
        {
            Assert.Fail();
        }
    }
}
