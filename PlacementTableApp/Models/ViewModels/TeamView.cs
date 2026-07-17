namespace PlacementTableApp.Models.ViewModels
{

    public class TeamView
    {
        public TeamView(int id, string? season, string? city, string? name, string? division, string? league)
        {
            Id = id;
            Season = season;
            City = city;
            Name = name;
            Division = division;
            League = league;
        }

        public TeamView()
        {
            Id = 0;
        }

        public int Id { get; set; }
        public string? Season { get; set; }
        public string? City { get; set; }
        public string? Name { get; set; }
        public string? Division { get; set; }
        public string? League { get; set; }

    }
}
