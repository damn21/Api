using System.ComponentModel.DataAnnotations;

namespace peliculasApi.DTOs
{
    public class GenreDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
