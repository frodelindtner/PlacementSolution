namespace PlacementTableApp.Models.ViewModels
{
    public class ResultView
    {
        public ResultView()
        {
            Id = 0;            
        }

        public ResultView(int id, string teamId, int wins, int losses)
        {
            Id = id;
            TeamId = teamId;
            Wins = wins;
            Losses = losses;
        }


        public int Id { get; set; } = 0;
        public string TeamId { get; set; } = string.Empty;
        public int Wins { get; set; } = int.MinValue;
        public int Losses { get; set; } = int.MinValue;


    }
}
