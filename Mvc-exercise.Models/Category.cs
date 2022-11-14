using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mvc_exercise.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display order")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    }
}