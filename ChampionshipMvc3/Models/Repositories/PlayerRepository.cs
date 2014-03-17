using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChampionshipMvc3.Models.Interfaces;
using ChampionshipMvc3.Models.DataContext;

namespace ChampionshipMvc3.Models.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public void AddNewPlayer(Player player)
        {
            player.PlayerID = Guid.NewGuid();
            RepositoryBase.DataContext.Players.InsertOnSubmit(player);
            SaveChanges();
        }

        public Player GetModel()
        {
            return new Player();
        }

        public ICollection<Player> GetAllPlayers()
        {
            return RepositoryBase.DataContext.Players.ToList();
        }

        public void SaveChanges()
        {
            RepositoryBase.DataContext.SubmitChanges();
        }
    }
}