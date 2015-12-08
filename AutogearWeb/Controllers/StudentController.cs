using System.Web.Mvc;
using AutogearWeb.Models;
using AutogearWeb.Repositories;
//using Microsoft.AspNet.Identity;

namespace AutogearWeb.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepo _iStudentRepo;
        private readonly IAutogearRepo _iAutogearRepo;
        public StudentController(IStudentRepo iStudentRepo,IAutogearRepo autogearRepo)
        {
            _iStudentRepo = iStudentRepo;
            _iAutogearRepo = autogearRepo;

        }
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var model = new StudentModel
            {
                GendersList = _iAutogearRepo.GenderListItems(),
                StatesList = _iStudentRepo.GetStateList(),
                LearningPackages = _iStudentRepo.GetPackages(),
                DrivingPackages = _iStudentRepo.GetPackages()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModel model)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
                //AddErrors(result);
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        //private void AddErrors(IdentityResult result)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error);
        //    }
        //}
    }
}