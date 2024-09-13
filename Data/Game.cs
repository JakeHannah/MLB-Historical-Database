using System;
using System.ComponentModel.DataAnnotations;

namespace MLBHistoricalDatabase.Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public int Neutral { get; set; }
        public int Season { get; set; }
        public DateTime Date { get; set; }
        public string? Playoff { get; set; }
        public string? AwayTeamScore { get; set; }
        public string? HomeTeamScore { get; set; }

        // Navigation property to TeamGameStats
        public List<TeamGameStats> TeamGameStats { get; set; } = new List<TeamGameStats>();
    }
}
