namespace PlacementTableApp.Models.DTOs
{
    public class ResultDTO(int id, string teamId, int wins, int losses)
    {
        public int Id { get; } = id;
        public string TeamId { get; set; } = teamId;
        public int Wins { get; set; } = wins;
        public int Losses { get; set; } = losses;


    }
}
