using ChampionshipMvc3.Models.Interfaces;
using ChampionshipMvc3.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChampionshipMvc3.Controllers
{
    public class AdminController : Controller
    {
        //TODO: Approve refreshes page;
        private const string adminViewName = "AdminView";

        private IPlayerRepository playerRepository;

        public AdminController()
        {
            playerRepository = new PlayerRepository();
        }
        //
        // GET: /AdminPlayfield/

        public ActionResult Index()
        {
            return View(adminViewName, playerRepository.GetAllUnapprovedPlayers());
        }

        public ActionResult Approve(Guid playerID)
        {
            playerRepository.ApprovePlayer(playerID);
            return View(adminViewName, playerRepository.GetAllUnapprovedPlayers());
        }
        //
        // GET: /AdminPlayfield/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /AdminPlayfield/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AdminPlayfield/Create

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
        
        //
        // GET: /AdminPlayfield/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /AdminPlayfield/Edit/5

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
        // GET: /AdminPlayfield/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /AdminPlayfield/Delete/5

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
