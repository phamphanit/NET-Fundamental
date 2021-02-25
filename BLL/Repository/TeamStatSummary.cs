using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
    public class TeamStatSummary
    {
        public long SeasonId { get; set; }
        public string Team { get; set; }
        public int GoalsFor { get; set; }
    }
    public class Game
    {
        public DateTime Date { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
    }
    public class Player
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
    }
    public class IndexViewModel
    {
        public List<Player> Players { get; set; }
        public List<Game> Games { get; set; }
    }
}
