using System.ComponentModel.DataAnnotations;

namespace day2.Models
{
    public class UniqeNameAttribute : ValidationAttribute
    {

        public string msg { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;
            string newName = value.ToString();
            DbSet context = new DbSet();
            Course coursedb = context.Courses.FirstOrDefault(s => s.Name == newName);
            if (coursedb != null)
            {
                return new ValidationResult("Name Must Be Unique");
            }
            return ValidationResult.Success;
        }
    }

}

