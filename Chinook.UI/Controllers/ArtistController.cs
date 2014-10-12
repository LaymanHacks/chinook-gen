using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chinook.Data.Repository;
using Chinook.Domain.Entities;

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
        public ActionResult Create(Artist artist)
        {
            try
            {
                _dbRepository.Insert(artist);

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
            return View(_dbRepository.GetDataByArtistId(id).FirstOrDefault());
        }

        // POST: Artist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Artist artist)
        {
            try
            {
                _dbRepository.Insert(artist);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(_dbRepository.GetDataByArtistId(id).FirstOrDefault());
            }
        }

       
        
    }
}
