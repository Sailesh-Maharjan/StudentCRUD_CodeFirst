using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCRUD_CodeFirst.Models
{
    public class Student
    {
        [Key]
        public int  Id { get; set; }

        [Required]
        [Column("StudentName",TypeName ="varchar(50)")]
        [Display(Name="StudentName")]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }
            
        [Required]
        public string Faculty { get; set; }

        [Required]
        [RegularExpression(@"^(?:\+977[- ]?)?(?:98\d{8}|97\d{8}|0\d{2,3}[- ]?\d{6,7})$")]
        public long PhoneNumber { get; set; }
    }
}
