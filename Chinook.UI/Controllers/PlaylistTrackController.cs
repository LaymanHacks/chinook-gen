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
    public class PlaylistTrackController : Controller
    {
        private readonly IPlaylistTrackRepository _dbPlaylistTrackRepository;
        private readonly IPlaylistRepository _dbPlaylistRepository;
        private readonly ITrackRepository _dbTrackRepository;
        

        public PlaylistTrackController(IPlaylistTrackRepository dbPlaylistTrackRepository, IPlaylistRepository dbPlaylistRepository, ITrackRepository dbTrackRepository)
        {
            _dbPlaylistTrackRepository = dbPlaylistTrackRepository;
            _dbPlaylistRepository = dbPlaylistRepository; 
            _dbTrackRepository = dbTrackRepository; 
            
        }
        
        // GET: PlaylistTrack
        public ActionResult Index()
        {
            return View();
        }

        // GET: PlaylistTrack/Details/5
        [Route("PlaylistTrack/Details/{playlistId}/{trackId}", Name = "GetPlaylistTrackDetails")]
        public ActionResult Details(Int32 playlistId, Int32 trackId)
        {
            return View(_dbPlaylistTrackRepository.GetDataByPlaylistIdTrackId(playlistId, trackId).FirstOrDefault());
        }

        // GET: PlaylistTrack/Create
        public ActionResult Create()
        {
            ViewBag.Playlists = new SelectList(_dbPlaylistRepository.GetData(), "PlaylistId", "PlaylistId");
            ViewBag.Tracks = new SelectList(_dbTrackRepository.GetData(), "TrackId", "TrackId");
            
            return View();
        }

        // POST: PlaylistTrack/Create
        [HttpPost]
        public ActionResult Create(PlaylistTrack playlistTrack)
        {
            try
            {
                _dbPlaylistTrackRepository.Insert(playlistTrack);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(playlistTrack);
            }
        }

        // GET: PlaylistTrack/Edit/5
        [Route("PlaylistTrack/Edit/{playlistId}/{trackId}", Name = "GetPlaylistTrackEdit")]
        public ActionResult Edit(Int32 playlistId, Int32 trackId)
        {
        	var playlistTrack = _dbPlaylistTrackRepository.GetDataByPlaylistIdTrackId(playlistId, trackId).FirstOrDefault();    
            if (playlistTrack != null) ViewBag.Playlists = new SelectList(_dbPlaylistRepository.GetData(), "PlaylistId", "PlaylistId", playlistTrack.PlaylistId);
            if (playlistTrack != null) ViewBag.Tracks = new SelectList(_dbTrackRepository.GetData(), "TrackId", "TrackId", playlistTrack.TrackId);
            
            return View(playlistTrack);
        }

        // POST: PlaylistTrack/Edit/5
        [Route("PlaylistTrack/Edit/{playlistId}/{trackId}", Name = "PostPlaylistTrackEdit")]
        [HttpPost]
        public ActionResult Edit(Int32 playlistId, Int32 trackId, PlaylistTrack playlistTrack)
        {
            try
            {
                _dbPlaylistTrackRepository.Update(playlistTrack);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(playlistTrack);
            }
        }
   }
}
