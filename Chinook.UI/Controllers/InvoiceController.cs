//------------------------------------------------------------------------------
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
using System.Web.Mvc;
using Chinook.Data.Repository;
using Chinook.Domain.Entities;

namespace Chinook.UI.Web.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _dbInvoiceRepository;
        private readonly ICustomerRepository _dbCustomerRepository;
        

        public InvoiceController(IInvoiceRepository dbInvoiceRepository, ICustomerRepository dbCustomerRepository)
        {
            _dbInvoiceRepository = dbInvoiceRepository;
            _dbCustomerRepository = dbCustomerRepository; 
            
        }
        
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }

        // GET: Invoice/Details/5
        [Route("Invoice/Details/{invoiceId}", Name = "GetInvoiceDetails")]
        public ActionResult Details(Int32 invoiceId)
        {
            return View(_dbInvoiceRepository.GetDataByInvoiceId(invoiceId).FirstOrDefault());
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            ViewBag.Customers = new SelectList(_dbCustomerRepository.GetData(), "CustomerId", "CustomerId");
            
            return View();
        }

        // POST: Invoice/Create
        [HttpPost]
        public ActionResult Create(Invoice invoice)
        {
            try
            {
                _dbInvoiceRepository.Insert(invoice);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(invoice);
            }
        }

        // GET: Invoice/Edit/5
        [Route("Invoice/Edit/{invoiceId}", Name = "GetInvoiceEdit")]
        public ActionResult Edit(Int32 invoiceId)
        {
        	var invoice = _dbInvoiceRepository.GetDataByInvoiceId(invoiceId).FirstOrDefault();    
            if (invoice != null) ViewBag.Customers = new SelectList(_dbCustomerRepository.GetData(), "CustomerId", "CustomerId", invoice.CustomerId);
            
            return View(invoice);
        }

        // POST: Invoice/Edit/5
        [Route("Invoice/Edit/{invoiceId}", Name = "PostInvoiceEdit")]
        [HttpPost]
        public ActionResult Edit(Int32 invoiceId, Invoice invoice)
        {
            try
            {
                _dbInvoiceRepository.Update(invoice);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(invoice);
            }
        }
   }
}
