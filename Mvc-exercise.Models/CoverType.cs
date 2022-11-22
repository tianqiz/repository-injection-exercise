using System.ComponentModel.DataAnnotations;

namespace Mvc_exercise.Models
{
    public class CoverType
    {
        public int Id { get; set; }

        [Display(Name = "Cover Type")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}