using System.Xml.Linq;

namespace PlacementTableApp.Models.DTOs.Output
{
    public class Standings
    {
        public Standings() { }

        public string? Season { get; set; }
        public string? SeasonType { get; set; }
        public int TeamId { get; set; }
        public string? City { get; set; }
        public string? Name { get; set; }
        public string? League { get; set; }
        public string? Division { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int NightWins { get; set; }

        public string ToJson()
        {
            return $"{{\"season\": \"{Season}\", \"seasonType\": \"{SeasonType}\", \"teamId\": {TeamId}, \"city\": \"{City}\", \"name\": \"{Name}\", \"league\": \"{League}\", \"division\": \"{Division}\", \"wins\": {Wins}, \"losses\": {Losses}, \"nightWins\": {NightWins}}}";
        }

    }
}
