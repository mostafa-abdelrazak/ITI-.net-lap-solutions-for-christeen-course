using System.ComponentModel.DataAnnotations.Schema;

namespace day2.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public string Img { get; set; }
        public string Address { get; set; }
        public int Grade { get; set; }
        //[ForeignKey(nameof(Department))]
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        public virtual Department Department { get; set; }
    }
}
