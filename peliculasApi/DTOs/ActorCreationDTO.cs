using System.ComponentModel.DataAnnotations;

namespace peliculasApi.DTOs
{
    public class ActorCreationDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime BirthdayDate { get; set; }
        public IFormFile Photo { get; set; }

    }
}
