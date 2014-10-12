﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chinook.Data.DbCommandProvider;
using Chinook.Data.Repository;

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

        // GET: Genre/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Genre/Edit/5
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

        // GET: Genre/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Genre/Delete/5
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