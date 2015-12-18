﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutogearWeb.Models;
using AutogearWeb.Repositories;
using Microsoft.AspNet.Identity;

namespace AutogearWeb.Controllers
{
    [Authorize]
    public class AutogearApiController : ApiController
    {
        private readonly IInstructorRepo _instructorRepo;
        private readonly IStudentRepo _studentRepo;
        private readonly IPostalRepo _postalRepo;

        public AutogearApiController()
        {
            
        }

        public AutogearApiController(IInstructorRepo instructorRepo,IStudentRepo studentRepo,IPostalRepo postalRepo)
        {
            _instructorRepo = instructorRepo;
            _studentRepo = studentRepo;
            _postalRepo = postalRepo;
        }

        public async Task<IList<TblInstructor>> GetInstructors()
        {
            return await _instructorRepo.GetInstructorList();
        }

        public async Task<IList<TblStudent>> GetStudents()
        {
            return await _studentRepo.GetStudentList();
        }

        public async Task<IList<int>> GetPostCodes(string suburbName)
        {
            return await _postalRepo.GetPostcodes(suburbName);
        }

        public async Task<IList<string>> GetSubUrbs(int? postCode)
        {
            return await _postalRepo.GetSuburbNames(postCode);
        }

        public async Task<IList<TblPostCodeSuburbModel>> GetPostalCodewithSuburbs()
        {
            return await _postalRepo.GetPostCodeWithSuburbs();
        }

        public async Task<IList<string>> GetInstructorNames()
        {
            return await _instructorRepo.GetInstructorNames();
        }

        public async Task<IList<InstructorBooking>> GetBookingEvents()
        {
            var currentUser = Request.GetOwinContext().Authentication.User.Identity.GetUserId();
            return await _instructorRepo.GetInstructorBookingEvents(currentUser);
        }

        public async Task<IList<StudentList>> GetStudentEvents()
        {
            var currentUser = Request.GetOwinContext().Authentication.User.Identity.GetUserId();
            return await _instructorRepo.GetStudentEvents(currentUser);
        }

        public async Task<IList<string>> GetStudentNames()
        {
            return await _studentRepo.GetStudentNames();
        }

        public void SaveBookingAppointment(BookingAppointment bookingAppointment)
        {
            var currentUser = Request.GetOwinContext().Authentication.User.Identity.GetUserId();
            _studentRepo.SaveStudentAppointment(bookingAppointment, currentUser);
        }
    }
}
