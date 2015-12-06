using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutogearWeb.Models;
using AutogearWeb.Repositories;

namespace AutogearWeb.Controllers
{
    public class AutogearApiController : ApiController
    {
        private readonly IInstructorRepo _instructorRepo;

        public AutogearApiController()
        {
            
        }

        public AutogearApiController(IInstructorRepo instructorRepo)
        {
            _instructorRepo = instructorRepo;
        }

        public async Task<IList<TblInstructor>> GetInstructors()
        {
            return await _instructorRepo.GetInstructorList();
        }

    }
}
