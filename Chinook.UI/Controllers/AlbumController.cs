using System.Linq;
using System.Web.Mvc;
using Chinook.Data.Repository;
using Chinook.Domain.Entities;

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
            return View();
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
        public ActionResult Create(Album album)
        {
            try
            {
                _dbRepository.Insert(album);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(album);
            }
        }

        // GET: Album/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_dbRepository.GetDataByAlbumId(id).FirstOrDefault());
        }

        // POST: Album/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Album album)
        {
            try
            {
                _dbRepository.Update(album);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(album);
            }
        }

    }
}
