using System.ComponentModel.DataAnnotations.Schema;

namespace day2.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        public virtual Department Department { get; set; }
        //[ForeignKey(nameof(Course))]
        [ForeignKey("Course")]
        public int Course_Id { get; set; }
        public virtual Course? Course { get; set; }





    }
}
