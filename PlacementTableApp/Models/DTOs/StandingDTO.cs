namespace PlacementTableApp.Models.DTOs
{
    public class StandingDTO(string season, string seasonType, int teamId, string city, string name, 
                            string league, string division, int wins, int losses, int nightWins)
    {
        public string Season { get; } = season;
        public string SeasonType { get; } = seasonType;
        public int TeamId { get; } = teamId;
        public string City { get; } = city;
        public string Name { get; } = name;
        public string League { get; } = league;
        public string Division { get; } = division;
        public int Wins { get; } = wins;
        public int Losses { get; } = losses;
        public int NightWins { get; } = nightWins;

        public string toJson() { 
            return $"{{\"season\": \"{Season}\", \"seasonType\": \"{SeasonType}\", \"teamId\": {TeamId}, \"city\": \"{City}\", \"name\": \"{Name}\", \"league\": \"{League}\", \"division\": \"{Division}\", \"wins\": {Wins}, \"losses\": {Losses}, \"nightWins\": {NightWins}}}";
        }
    }


}
