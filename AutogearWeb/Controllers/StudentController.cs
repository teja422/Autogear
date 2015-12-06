using System.Web.Mvc;
using AutogearWeb.Repositories;

namespace AutogearWeb.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepo _iStudentRepo;
        public StudentController(IStudentRepo iStudentRepo)
        {
            _iStudentRepo = iStudentRepo;
        }
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}