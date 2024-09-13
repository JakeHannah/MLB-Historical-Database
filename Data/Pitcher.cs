using System.ComponentModel.DataAnnotations;

namespace MLBHistoricalDatabase.Data
{
    public class Pitcher
    {
        [Key]
        public int PitcherId { get; set; }
        public string? Name { get; set; }
        public float PitcherRgs { get; set; }
        public float PitcherAdj { get; set; }
    }
}
