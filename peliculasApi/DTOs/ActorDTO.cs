using System.ComponentModel.DataAnnotations;

namespace peliculasApi.DTOs
{
    public class ActorDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Photo { get; set; }
    }
}
