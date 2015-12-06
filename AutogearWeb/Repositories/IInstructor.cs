using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutogearWeb.EFModels;
using AutogearWeb.Models;

namespace AutogearWeb.Repositories
{
    public interface IInstructor : IDisposable
    {
        autogearEntities DataContext { get; set; }
        IList<SelectListItem> GenderListItems();

        IQueryable<TblInstructor> TblInstructors { get; set; }
        Task<IList<TblInstructor>> GetInstructorList(); // Fetch List
        Instructor GetInstructorByEmail(string email); // Fetch by Email
        void AddIntructor(Instructor repo); // Add new instructor
        void SaveInDatabase();  // Save Asynchronous

    }
}
