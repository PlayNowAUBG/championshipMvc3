using ChampionshipMvc3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public void AddNewTeam(Team team)
        {
            RepositoryBase.DataContext.Teams.InsertOnSubmit(team);
            SaveChanges();
        }

        public Team GetModel()
        {
            return new Team();
        }

        public ICollection<Team> GetAllTeams()
        {
            return RepositoryBase.DataContext.Teams.ToList();
        }

        public void SaveChanges()
        {
            RepositoryBase.DataContext.SubmitChanges();
        }
    }
}