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
        public IActionResult Delete(int id)
        {
            Course s = DB.Courses.FirstOrDefault(x => x.Id == id);
            return View(s);
        }
        [HttpPost]
        public IActionResult Delete(Course s)
        {


            DB.Courses.Remove(s);
            DB.SaveChanges();

            return RedirectToAction("Index");
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
                if (s.Dept_id != 0)
                {
                    DB.Courses.Add(s);
                    DB.SaveChanges();
                    return RedirectToAction("Index", "Course");
                }
                else
                {
                    ModelState.AddModelError("", "Select Department");
                }
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

        public IActionResult CheckDegree(int MinDegree, int Degree)
        {
            if (MinDegree < Degree)
                return Json(true);
            return Json(false);
        }
    }
}
