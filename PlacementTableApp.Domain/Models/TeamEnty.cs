using System;
using System.Collections.Generic;
using System.Text;

namespace PlacementTableApp.Repositories.Models
{
    public class TeamEnty
    {
        public int Id { get; set; }
        public string? Season { get; set; }
        public string? City { get; set; }
        public string? Name { get; set; }
        public string? Division { get; set; }
        public string? League { get; set; }
    }
}
