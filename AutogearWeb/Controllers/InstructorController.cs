using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutogearWeb.EFModels;
using AutogearWeb.Models;
using AutogearWeb.Repositories;
using Microsoft.AspNet.Identity;

namespace AutogearWeb.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationRoleManager _roleManager;
        private readonly IInstructor _instructorRepo;


        public InstructorController()
        {
        }
        public InstructorController(ApplicationUserManager userManager, ApplicationRoleManager roleManager, IInstructor instructorRepo)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _instructorRepo = instructorRepo;
        }

        

        // GET: Instructor
        public ActionResult Index()
        {
            return View(_instructorRepo.GetInstructorList());
        }

        public ActionResult Create()
        {
            var model = new RegisterViewModel
            {
                GendersList = new SelectList(_instructorRepo.GenderListItems(), "Value", "Text")
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //Add role instructor to created user
                    // Fetch role
                    var role = await _roleManager.FindByNameAsync("Instructor");
                    if (role != null)
                    {
                         _userManager.AddToRole(user.Id, role.Name);
                    }
                    // Create Instructor account
                    var instructor = new Instructor
                    {
                        Created_Date = DateTime.Now,
                        InstructorId = user.Id,
                        Created_By = User.Identity.GetUserId()
                    };
                    TryUpdateModel(instructor);
                    _instructorRepo.AddIntructor(instructor);
                    _instructorRepo.SaveInDatabase();
                    //await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }
            return View(model);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

    }

}