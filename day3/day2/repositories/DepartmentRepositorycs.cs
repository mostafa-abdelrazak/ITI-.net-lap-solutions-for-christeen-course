using day2.Models;

namespace day2.repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        DbSet DB;//= new DbSet();
        public DepartmentRepository(DbSet _DB)
        {
            DB = _DB;

        }


        public void Delete(int id)
        {
            Department d = DB.Departments.FirstOrDefault(x => x.Id == id);
            DB.Departments.Remove(d);
            DB.SaveChanges();
        }

        public Department Detail(int Id)
        {
            Department d = DB.Departments.FirstOrDefault(x => x.Id == Id);
            return d;

        }

        public void Edit(Department d, int id)
        {
            Department Old = Detail(id);
            d.Name = Old.Name;
            d.Manager = Old.Manager;
            DB.SaveChanges();

        }

        public List<Department> GetAll()
        {
            return DB.Departments.ToList();
        }

        public void New(Department d)
        {
            DB.Departments.Add(d);
            DB.SaveChanges();
        }
    }
}
