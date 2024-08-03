using day2.Models;
using day2.repositories;
using Microsoft.AspNetCore.Mvc;

namespace day2.Controllers
{
    public class CourseController : Controller
    {
        //DbSet DB = new DbSet();
        ICourseRepository courseRepository;
        IDepartmentRepository departmentRepository;
        public CourseController(IDepartmentRepository _departmentRepository, ICourseRepository _courseRepository)
        {

            this.departmentRepository = _departmentRepository;
            this.courseRepository = _courseRepository;

        }
        public IActionResult Index()
        {

            List<Course> courses = courseRepository.GetAll();//DB.Courses.ToList();

            return View(courses);
        }
        public IActionResult Detail(int Id)
        {
            Course course = courseRepository.Detail(Id);//DB.Courses.FirstOrDefault(x => x.Id == Id);
            return View(course);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Course s = courseRepository.Detail(id);//DB.Courses.FirstOrDefault(x => x.Id == id);
            return View(s);
        }
        [HttpPost]
        public IActionResult Delete(Course s)
        {


            // DB.Courses.Remove(s);
            //DB.SaveChanges();
            courseRepository.Delete(s.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult New()
        {
            List<Department> depts = departmentRepository.GetAll();//DB.Departments.ToList();
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
                    //DB.Courses.Add(s);
                    //DB.SaveChanges();
                    courseRepository.New(s);
                    return RedirectToAction("Index", "Course");
                }
                else
                {
                    ModelState.AddModelError("", "Select Department");
                }
            }
            List<Department> depts = departmentRepository.GetAll();//DB.Departments.ToList();
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
