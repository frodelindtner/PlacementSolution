using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlacementTableApp.Storage.Models
{
    [Table("movie")]
    public class Movie
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string? Title { get; set; }
    }
}
