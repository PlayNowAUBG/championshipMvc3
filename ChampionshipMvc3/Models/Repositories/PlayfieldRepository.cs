using ChampionshipMvc3.Models.DataContext;
using ChampionshipMvc3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Repositories
{
    public class PlayfieldRepository : IPlayfieldRepository
    {
        public void AddNewPlayfield(Playfield playfield)
        {
            Guid newID = Guid.NewGuid();
            playfield.PLayfieldID = newID;
            RepositoryBase.DataContext.Playfields.InsertOnSubmit(playfield);
            SaveChanges();
        }

        public Playfield GetModel()
        {
            return new Playfield();
        }


        public void SaveChanges()
        {
            RepositoryBase.DataContext.SubmitChanges();
        }
    }
}