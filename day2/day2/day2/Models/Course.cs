using System.ComponentModel.DataAnnotations.Schema;

namespace day2.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        [ForeignKey("Department")]
        // [ForeignKey(nameof(Department))]
        public int Dept_id { get; set; }
        public virtual Department Department { get; set; }
    }
}
