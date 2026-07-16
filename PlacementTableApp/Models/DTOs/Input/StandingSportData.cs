namespace PlacementTableApp.Models.DTOs.Input
{
    public class StandingSportData
    {
        public int Season { get; set; }
        public int SeasonType { get; set; }
        public int TeamId { get; set; }
        public string? City { get; set; }
        public string? Name { get; set; }
        public string? League { get; set; }
        public string? Division { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int NightWins { get; set; }
    }
}
