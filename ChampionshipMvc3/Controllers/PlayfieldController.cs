using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChampionshipMvc3.Models.Interfaces;
using ChampionshipMvc3.Models.Repositories;
using ChampionshipMvc3.Models.DataContext;
using System.IO;
using ChampionshipMvc3.Models.ViewModels;
using ChampionshipMvc3.Common;

namespace ChampionshipMvc3.Controllers
{

    public class PlayfieldController : Controller
    {

        private const string locationString = "~/Images/";
        private IPlayfieldRepository playfieldRepository;
        private IScheduleRepository scheduleRepository;

        public PlayfieldController()
        {
            playfieldRepository = new PlayfieldRepository();
            scheduleRepository = new ScheduleRepository();
        }


        //
        // GET: /Playfield/Details/5

        public ActionResult Details(Guid id)
        {
            var playfield = playfieldRepository.GetPlayfieldById(id);
            return View("PlayfieldDetails", playfield);
        }

        
        //
        // GET: /Playfield/Create

        public ActionResult Create()
        {
            return View("CreatePlayfield", playfieldRepository.GetModel());
        }

        //
        // POST: /Playfield/Create

        [HttpPost]
        public ActionResult Create(Playfield playfieldModel, FileViewModel fileViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Schedule teamSchedule = new Schedule();
                    scheduleRepository.AddNewSchedule(teamSchedule);
                    playfieldModel.Schedule = teamSchedule;
                    playfieldModel.ImageLink = SaveToServer(fileViewModel).Replace("~/", string.Empty);
                    playfieldRepository.AddNewPlayfield(playfieldModel);
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ReservePlayfield(Guid hourId)
        {
            return RedirectToAction("Index", "Home");
        }

        //
        // POST: /Playfield/Delete/5

        private string SaveToServer(FileViewModel fileViewModel)
        {
            string location = locationString + fileViewModel.File.FileName;
            fileViewModel.File.SaveAs(Server.MapPath(location));

            return location;
        }
    }
}
