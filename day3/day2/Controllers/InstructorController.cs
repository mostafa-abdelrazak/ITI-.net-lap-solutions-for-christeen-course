using day2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day2.Controllers
{
    public class InstructorController : Controller
    {
        DbSet data = new DbSet();
        public IActionResult Index()
        {
            List<Instructor> list = new List<Instructor>();
            list = data.Instructors.ToList();
            return View(list);
        }
        public IActionResult Detail(int id)
        {
            Instructor instructor = new Instructor();
            instructor = data.Instructors.Include(z => z.Department).FirstOrDefault(x => x.Id == id);
            return View(instructor);
        }
    }
}
