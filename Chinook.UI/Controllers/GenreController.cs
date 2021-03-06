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
    public class GenreController : Controller
    {
        private readonly IGenreRepository _dbGenreRepository;
        

        public GenreController(IGenreRepository dbGenreRepository)
        {
            _dbGenreRepository = dbGenreRepository;
            
        }
        
        // GET: Genre
        public ActionResult Index()
        {
            return View();
        }

        // GET: Genre/Details/5
        [Route("Genre/Details/{genreId}", Name = "GetGenreDetails")]
        public ActionResult Details(Int32 genreId)
        {
            return View(_dbGenreRepository.GetDataByGenreId(genreId).FirstOrDefault());
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
                _dbGenreRepository.Insert(genre);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(genre);
            }
        }

        // GET: Genre/Edit/5
        [Route("Genre/Edit/{genreId}", Name = "GetGenreEdit")]
        public ActionResult Edit(Int32 genreId)
        {
        	var genre = _dbGenreRepository.GetDataByGenreId(genreId).FirstOrDefault();    
            
            return View(genre);
        }

        // POST: Genre/Edit/5
        [Route("Genre/Edit/{genreId}", Name = "PostGenreEdit")]
        [HttpPost]
        public ActionResult Edit(Int32 genreId, Genre genre)
        {
            try
            {
                _dbGenreRepository.Update(genre);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(genre);
            }
        }
   }
}
