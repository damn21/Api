using System.ComponentModel.DataAnnotations;

namespace peliculasApi.DTOs
{
    public class GenreCreationDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
