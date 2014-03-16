using ChampionshipMvc3.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Interfaces
{
    public interface IPlayerRepository
    {
        void AddNewPlayer(Player player);
        Player GetModel();
        ICollection<Player> GetAllPlayers();
        void SaveChanges();
    }
}