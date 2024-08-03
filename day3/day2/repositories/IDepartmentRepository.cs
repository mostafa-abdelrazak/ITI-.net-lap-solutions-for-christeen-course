using day2.Models;

namespace day2.repositories
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department Detail(int Id);
        void Delete(int id);
        void New(Department d);
        void Edit(Department d, int id);
    }
}
