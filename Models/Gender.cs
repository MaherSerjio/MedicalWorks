using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2.Models
{
    [Table("Genders")]
    public class Gender
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Type { get; set; }

    }
}
