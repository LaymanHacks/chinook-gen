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
    public class InvoiceLineController : Controller
    {
        private readonly IInvoiceLineRepository _dbInvoiceLineRepository;
        private readonly IInvoiceRepository _dbInvoiceRepository;
        private readonly ITrackRepository _dbTrackRepository;
        

        public InvoiceLineController(IInvoiceLineRepository dbInvoiceLineRepository, IInvoiceRepository dbInvoiceRepository, ITrackRepository dbTrackRepository)
        {
            _dbInvoiceLineRepository = dbInvoiceLineRepository;
            _dbInvoiceRepository = dbInvoiceRepository; 
            _dbTrackRepository = dbTrackRepository; 
            
        }
        
        // GET: InvoiceLine
        public ActionResult Index()
        {
            return View();
        }

        // GET: InvoiceLine/Details/5
        [Route("InvoiceLine/Details/{invoiceLineId}", Name = "GetInvoiceLineDetails")]
        public ActionResult Details(Int32 invoiceLineId)
        {
            return View(_dbInvoiceLineRepository.GetDataByInvoiceLineId(invoiceLineId).FirstOrDefault());
        }

        // GET: InvoiceLine/Create
        public ActionResult Create()
        {
            ViewBag.Invoices = new SelectList(_dbInvoiceRepository.GetData(), "InvoiceId", "InvoiceId");
            ViewBag.Tracks = new SelectList(_dbTrackRepository.GetData(), "TrackId", "TrackId");
            
            return View();
        }

        // POST: InvoiceLine/Create
        [HttpPost]
        public ActionResult Create(InvoiceLine invoiceLine)
        {
            try
            {
                _dbInvoiceLineRepository.Insert(invoiceLine);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(invoiceLine);
            }
        }

        // GET: InvoiceLine/Edit/5
        [Route("InvoiceLine/Edit/{invoiceLineId}", Name = "GetInvoiceLineEdit")]
        public ActionResult Edit(Int32 invoiceLineId)
        {
        	var invoiceLine = _dbInvoiceLineRepository.GetDataByInvoiceLineId(invoiceLineId).FirstOrDefault();    
            if (invoiceLine != null) ViewBag.Invoices = new SelectList(_dbInvoiceRepository.GetData(), "InvoiceId", "InvoiceId", invoiceLine.InvoiceId);
            if (invoiceLine != null) ViewBag.Tracks = new SelectList(_dbTrackRepository.GetData(), "TrackId", "TrackId", invoiceLine.TrackId);
            
            return View(invoiceLine);
        }

        // POST: InvoiceLine/Edit/5
        [Route("InvoiceLine/Edit/{invoiceLineId}", Name = "PostInvoiceLineEdit")]
        [HttpPost]
        public ActionResult Edit(Int32 invoiceLineId, InvoiceLine invoiceLine)
        {
            try
            {
                _dbInvoiceLineRepository.Update(invoiceLine);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(invoiceLine);
            }
        }
   }
}
