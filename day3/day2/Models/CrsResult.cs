using System.ComponentModel.DataAnnotations.Schema;

namespace day2.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }
        //[ForeignKey(nameof(Course))]
        [ForeignKey("Course")]
        public int Corse_Id { get; set; }
        public virtual Course Course { get; set; }

        [ForeignKey("Trainee")]
        public int Trainee_Id { get; set; }
        public virtual Trainee Trainee { get; set; }

    }
}
