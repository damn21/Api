using System.ComponentModel.DataAnnotations;

namespace peliculasApi.Entity
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
