using day2.Models;

namespace day2.repositories
{
    public class CourseRepository : ICourseRepository
    {
        DbSet DB;//= new DbSet();
        public CourseRepository(DbSet _DB)
        {
            DB = _DB;
        }
        public void Delete(int id)
        {

            Course s = DB.Courses.FirstOrDefault(c => c.Id == id);
            DB.Courses.Remove(s);
            DB.SaveChanges();
        }

        public Course Detail(int Id)
        {
            Course c = DB.Courses.FirstOrDefault(x => x.Id == Id);
            return c;
        }

        public void Edit(Course s, int Id)
        {
            Course c = DB.Courses.FirstOrDefault(x => x.Id == Id);
            c.Name = s.Name;
            c.MinDegree = s.MinDegree;
            c.Degree = s.Degree;
            c.Dept_id = s.Dept_id;
            DB.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return DB.Courses.ToList();
        }

        public void New(Course s)
        {
            DB.Courses.Add(s);
            DB.SaveChanges();
        }
    }
}
