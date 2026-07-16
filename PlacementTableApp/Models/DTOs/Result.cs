namespace PlacementTableApp.Models.DTOs
{
    public class Result(int id, int teamId, int wins, int losses)
    {
        public int Id { get; } = id;
        public int TeamId { get; set; } = teamId;
        public int Wins { get; set; } = wins;
        public int Losses { get; set; } = losses;


    }
}
