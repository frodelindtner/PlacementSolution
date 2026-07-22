using System;
using System.Collections.Generic;
using System.Text;

namespace PlacementTableApp.Repositories.Models
{
    public class ResultEnty
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
