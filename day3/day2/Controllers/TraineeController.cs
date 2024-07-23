using day2.Models;
using day2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day2.Controllers
{

    public class TraineeController : Controller
    {
        DbSet DB = new DbSet();
        public IActionResult Index()
        {
            List<Trainee> trainees = DB.Trainees.ToList();
            return View(trainees);
        }

        [HttpGet]
        public IActionResult add()
        {
            List<Department> model = DB.Departments.Where(x => true).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult add(Trainee t)
        {
            DB.Trainees.Add(t);
            DB.SaveChanges();
            return Content("Trainee Added");
        }
        [HttpGet]
        public IActionResult update(int id)
        {

            List<Department> depts = DB.Departments.Where(x => true).ToList();
            ViewBag.Depts = depts;
            Trainee model = DB.Trainees.FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        public IActionResult update(int id, Trainee trainee)
        {
            Trainee oldtrainee = DB.Trainees.FirstOrDefault(s => s.Id == id);


            //get old object
            oldtrainee.Name = trainee.Name;
            oldtrainee.Address = trainee.Address;
            oldtrainee.Grade = trainee.Grade;
            oldtrainee.Img = trainee.Img;
            oldtrainee.Dept_Id = trainee.Dept_Id;
            DB.SaveChanges();
            return RedirectToAction("Index");
            //  return Content("Trainee Updated");
        }

        public IActionResult delete(int id)
        {
            DB.Remove(id);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }





        public IActionResult Detail(int Id)
        {
            CrsResultWithNames_Color_StatusViewModel Temp = new CrsResultWithNames_Color_StatusViewModel();
            List<CrsResultWithNames_Color_StatusViewModel> modell = new List<CrsResultWithNames_Color_StatusViewModel>();
            List<CrsResult> crsResults = DB.CrsResults.Include(x => x.Trainee).Include(x => x.Course).Where(x => x.Id == Id).ToList();
            foreach (CrsResult crs in crsResults)
            {
                Temp.Name = crs.Trainee.Name;
                Temp.Degree = crs.Degree;
                Temp.CrsName = crs.Course.Name;
                if (crs.Degree >= 50)
                {
                    Temp.Color = "Green";
                    Temp.Passed = true;
                }
                else
                {
                    Temp.Color = "Red";
                    Temp.Passed = false;

                }

                modell.Add(Temp);


            }

            return View(modell);

        }
    }
}
