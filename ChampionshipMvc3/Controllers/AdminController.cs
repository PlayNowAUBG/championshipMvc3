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
        private const string pendingRequests = "PendingRequests";
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

        public ActionResult ApprovePlayer(Guid playerID)
        {
            playerRepository.ApprovePlayer(playerID);

            return PartialView(pendingRequests, playerRepository.GetAllUnapprovedPlayers());
        }

        public ActionResult UnapprovedPlayers()
        {
            return PartialView(pendingRequests, playerRepository.GetAllUnapprovedPlayers());
        }
    }
}
