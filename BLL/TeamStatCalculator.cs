using BLL.Repository;
using System;
using System.Linq;

namespace BLL
{
    public class TeamStatCalculator
    {
        private readonly ITeamStatRepository _teamStatRepository;

        public TeamStatCalculator(ITeamStatRepository teamStatRepository)
        {
            _teamStatRepository = teamStatRepository;
        }

        public int GetTotalGoalsForSeason(int seasonId)
        {
            // get all the team stats for the given season
            var teamStatsBySeason = _teamStatRepository
            .FindAll(ts => ts.SeasonId == seasonId);

            // sum and return the total goals
            return teamStatsBySeason.Sum(ts => ts.GoalsFor);
        }
    }
}
