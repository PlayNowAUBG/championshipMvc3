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
        // GET: /Playfield/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Playfield/Details/5

        public ActionResult Details(int id)
        {
            return View();
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
                    playfieldModel.ImageLink = SaveToServer(fileViewModel);
                    playfieldRepository.AddNewPlayfield(playfieldModel);
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }



        //
        // GET: /Playfield/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Playfield/Edit/5

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

        //
        // GET: /Playfield/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Playfield/Delete/5

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

        private string SaveToServer(FileViewModel fileViewModel)
        {
            string location = locationString + fileViewModel.File.FileName;
            fileViewModel.File.SaveAs(Server.MapPath(location));

            return location;
        }
    }
}
