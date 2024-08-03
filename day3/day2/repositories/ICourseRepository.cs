using day2.Models;

namespace day2.repositories
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course Detail(int Id);
        void Delete(int id);
        void New(Course s);
        void Edit(Course s, int Id);

    }
}
