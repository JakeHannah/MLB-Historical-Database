using System.ComponentModel.DataAnnotations;

namespace MLBHistoricalDatabase.Data
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string? Name { get; set; }
        public float RatingPost { get; set; }
        public float RatingProb { get; set; }
        public float RatingPre { get; set; }
        public string? Logo { get; set; }
        public string? FullName { get; set; }
    }
}
