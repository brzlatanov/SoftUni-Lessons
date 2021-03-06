using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {

        public int TeamId { get; set; }
        public decimal Budget { get; set; }
        [MaxLength(3)]
        public string Initials { get; set; }
        public string LogoUrl { get; set; }

        public string Name { get; set; }

        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }
        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }
        public Town Town { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
        [InverseProperty("HomeTeam")] public ICollection<Game> HomeGames { get; set; } = new List<Game>();

        [InverseProperty("AwayTeam")] public ICollection<Game> AwayGames { get; set; } = new List<Game>();
    }

}
