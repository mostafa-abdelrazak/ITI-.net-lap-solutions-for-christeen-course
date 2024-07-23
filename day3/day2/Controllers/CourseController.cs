using day2.Models;
using Microsoft.AspNetCore.Mvc;

namespace day2.Controllers
{
    public class CourseController : Controller
    {
        DbSet DB = new DbSet();
        public IActionResult Index()
        {

            List<Course> courses = DB.Courses.ToList();

            return View(courses);
        }
        public IActionResult Detail(int Id)
        {
            Course course = DB.Courses.FirstOrDefault(x => x.Id == Id);
            return View(course);
        }

        [HttpGet]
        public IActionResult New()
        {
            List<Department> depts = DB.Departments.ToList();
            ViewBag.Departments = depts;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Course s)
        {

            if (ModelState.IsValid)
            {
                DB.Courses.Add(s);
                DB.SaveChanges();
                return RedirectToAction("Index", "Course");
            }
            List<Department> depts = DB.Departments.ToList();
            ViewBag.Departments = depts;
            return View("new", s);
        }





        //session testing 
        public IActionResult addsession()
        {
            HttpContext.Session.SetString("mostafa", "mostafaaha3");
            return Content("session saved");
        }

        public IActionResult getsession()
        {
            string s = HttpContext.Session.GetString("mostafa");
            return Content(s);
        }
    }
}
