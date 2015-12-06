using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutogearWeb.Models;
using AutogearWeb.Repositories;

namespace AutogearWeb.Controllers
{
    public class AutogearApiController : ApiController
    {
        private readonly IInstructor _instructorRepo;

        public AutogearApiController()
        {
            
        }

        public AutogearApiController(IInstructor instructorRepo)
        {
            _instructorRepo = instructorRepo;
        }

        public async Task<IList<TblInstructor>> GetInstructors()
        {
            return await _instructorRepo.GetInstructorList();
        }

    }
}
