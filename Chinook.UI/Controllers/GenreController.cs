using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chinook.Data.DbCommandProvider;
using Chinook.Data.Repository;
using Chinook.Domain.Entities;

namespace Chinook.Web.UI.Controllers
{
    public class GenreController : Controller
    {
         private readonly IGenreRepository _dbRepository;

        public GenreController(IDbGenreCommandProvider dbCommandProvider)
        {
            _dbRepository = new DbGenreRepository(dbCommandProvider);
        }
        // GET: Genre
        public ActionResult Index()
        {
            return View(_dbRepository.GetData());
        }

        // GET: Genre/Details/5
        public ActionResult Details(int id)
        {
            return View(_dbRepository.GetDataByGenreId(id).FirstOrDefault());
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            try
            {
                _dbRepository.Insert(genre);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(genre);
            }
        }

        // GET: Genre/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_dbRepository.GetDataByGenreId(id).First());
        }

        // POST: Genre/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Genre genre)
        {
            try
            {
                _dbRepository.Update(genre);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(genre);
            }
        }

     
    }
}
