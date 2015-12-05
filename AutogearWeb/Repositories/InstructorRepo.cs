using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutogearWeb.EFModels;

namespace AutogearWeb.Repositories
{
    public class InstructorRepo : IInstructor
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public autogearEntities DataContext { get; set; }

        public  InstructorRepo()
        {
            DataContext = new autogearEntities();
        }


        public IList<SelectListItem> GenderListItems()
        {
            string[] list = {"", "Male", "Female"};
            var genderList = new List<SelectListItem>();
            var i = 0;
            foreach (var gender in list)
            {
                genderList.Add(new SelectListItem {Value = i.ToString(), Text = gender});
                i++;
            }
            return genderList;
        }

        public IList<Instructor> GetInstructorList()
        {
            return DataContext.Instructors.ToList();
        }

        public void AddIntructor(Instructor repo)
        {
            DataContext.Instructors.Add(repo);
        }

        public Instructor GetInstructorByEmail(string email)
        {
            return DataContext.Instructors.SingleOrDefault(s => s.Email == email);
        }

        public void SaveInDatabase()
        {
            DataContext.SaveChangesAsync();
        }
    }
}