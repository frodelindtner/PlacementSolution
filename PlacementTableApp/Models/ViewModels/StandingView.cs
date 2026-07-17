namespace PlacementTableApp.Models.ViewModels
{
    public class StandingView
    {
        public StandingView() {

        }

        public StandingView(string season, string seasonType, int teamId, string city, string name,
                            string league, string division, int wins, int losses, int nightWins)
        {
            Season = season;
            SeasonType = seasonType;
            TeamId = teamId;
            City = city;
            Name = name;
            League = league;
            Division = division;
            Wins = wins;
            Losses = losses;
            NightWins = nightWins;
        }

        public string Season { get; set; }
        public string SeasonType { get; set; }
        public int TeamId { get; set; }
        public string City { get; set; }
        public string Name { get; set;  }
        public string League { get; set; }
        public string Division { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int NightWins { get; set; }

        public string toJson() { 
            return $"{{\"season\": \"{Season}\", \"seasonType\": \"{SeasonType}\", \"teamId\": {TeamId}, \"city\": \"{City}\", \"name\": \"{Name}\", \"league\": \"{League}\", \"division\": \"{Division}\", \"wins\": {Wins}, \"losses\": {Losses}, \"nightWins\": {NightWins}}}";
        }
    }


}
