using System.ComponentModel.DataAnnotations;

namespace peliculasApi.Entity
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Title { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public int MovieId { get; set; }

    }
}
