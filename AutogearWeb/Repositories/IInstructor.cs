using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutogearWeb.EFModels;

namespace AutogearWeb.Repositories
{
    public interface IInstructor : IDisposable
    {
        autogearEntities DataContext { get; set; }
        IList<SelectListItem> GenderListItems();

        IList<Instructor> GetInstructorList();  // Fetch List
        Instructor GetInstructorByEmail(string email); // Fetch by Email
        void AddIntructor(Instructor repo); // Add new instructor
        void SaveInDatabase();  // Save Asynchronous

    }
}
