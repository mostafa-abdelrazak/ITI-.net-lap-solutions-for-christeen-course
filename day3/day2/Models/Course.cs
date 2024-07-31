using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace day2.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [UniqeName]
        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [Range(minimum: 50, maximum: 100)]
        public int Degree { get; set; }

        [Required]
        [Remote(action: "CheckDegree", controller: "Course", ErrorMessage = "min degree must be less than degree", AdditionalFields = "Degree")]
        public int MinDegree { get; set; }
        [ForeignKey("Department")]
        // [ForeignKey(nameof(Department))]
        [Display(Name = "Department")]
        public int Dept_id { get; set; }

        public virtual Department? Department { get; set; }
    }
}
