using System.ComponentModel.DataAnnotations;

namespace HMDB_API.Models.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Director { get; set; }

        public float Rating { get; set; }
    }
}
