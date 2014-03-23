using ChampionshipMvc3.Models.DataContext;
using ChampionshipMvc3.Models.Enums;
using ChampionshipMvc3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {

        public Schedule GetModel()
        {
            return new Schedule();
        }

        public void AddNewSchedule(Schedule schedule)
        {
            Guid scheduleGuid = Guid.NewGuid();
            AddDaysToSchedule(schedule);
            schedule.ScheduleID = scheduleGuid;

            RepositoryBase.DataContext.Schedules.InsertOnSubmit(schedule);
            SaveChanges();
        }

        public Schedule GetTeamSchedule(Guid teamId)
        {
            throw new NotImplementedException();
        }

        public Schedule GetPlayerSchedule(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public Schedule GetPlayFieldSchedule(Guid playFieldId)
        {
            throw new NotImplementedException();
        }

        private void AddDaysToSchedule(Schedule schedule)
        {
            for (int dayIndex = 0; dayIndex < 7; dayIndex++)
            {
                Day newDay = new Day();
                newDay.DaysID = Guid.NewGuid();
                newDay.DayName = ((DaysEnum)dayIndex).ToString();
                newDay.Schedule = schedule;

                AddHoursToDay(newDay);

                RepositoryBase.DataContext.Days.InsertOnSubmit(newDay);
            }
        }

        private void AddHoursToDay(Day currentDay)
        {
            Hour hours = new Hour();
            hours.Day = currentDay;
            hours.HoursID = Guid.NewGuid();

            RepositoryBase.DataContext.Hours.InsertOnSubmit(hours);
        }

        public void SaveChanges()
        {
            RepositoryBase.DataContext.SubmitChanges();
        }
    }
}