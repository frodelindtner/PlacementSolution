namespace PlacementTableApp.Models.DTOs
{
    public class Team(int id, string season, string city, string name, string division, string league)
    {
        public int Id { get; } = id;
        public string Season { get; set; } = season;
        public string City { get; set; } = city;
        public string Name { get; set; } = name;
        public string Division { get; set; } = division;
        public string League { get; set; } = league;

    }
}
