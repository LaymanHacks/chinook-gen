﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chinook.Data.Repository;

namespace Chinook.Web.UI.Controllers
{
    public class AlbumController : Controller
    {
       private readonly IAlbumRepository _dbRepository;

        public AlbumController(IAlbumRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        // GET: Album
        public ActionResult Index()
        {
            return View(_dbRepository.GetData());
        }

        // GET: Album/Details/5
        public ActionResult Details(int id)
        {
            return View(_dbRepository.GetDataByAlbumId(id).FirstOrDefault());
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
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

        // GET: Album/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_dbRepository.GetDataByAlbumId(id).FirstOrDefault());
        }

        // POST: Album/Edit/5
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

        // GET: Album/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Album/Delete/5
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
