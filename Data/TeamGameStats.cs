using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLBHistoricalDatabase.Data
{
    public class TeamGameStats
    {
        [Key, Column(Order = 0), ForeignKey("Game")]
        public int GameId { get; set; }
        [Key, Column(Order = 1), ForeignKey("Team")]
        public int TeamId { get; set; }

        public bool IsHome { get; set; }
        public int Score { get; set; }

        [ForeignKey("Pitcher")]
        public int PitcherId { get; set; }

        // Navigation properties
        public Team Team { get; set; }
        public Pitcher Pitcher { get; set; }
    }
}
