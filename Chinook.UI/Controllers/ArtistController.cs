using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chinook.Data.Repository;

namespace Chinook.Web.UI.Controllers
{
    public class ArtistController : Controller
    {
         private readonly IArtistRepository _dbRepository;

        public ArtistController(IArtistRepository artistRepository)
        {
            _dbRepository = artistRepository;
        }

        // GET: Artist
        public ActionResult Index()
        {
            return View();
        }

        // GET: Artist/Details/5
        public ActionResult Details(int id)
        {
            return View(_dbRepository.GetDataByArtistId(id).FirstOrDefault());
        }

        // GET: Artist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artist/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Artist/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Artist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Artist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Artist/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
