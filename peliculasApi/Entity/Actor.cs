using System.ComponentModel.DataAnnotations;

namespace peliculasApi.Entity
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Photo { get; set; }
    }
}
