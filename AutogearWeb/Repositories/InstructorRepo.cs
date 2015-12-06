using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutogearWeb.EFModels;
using AutogearWeb.Models;

namespace AutogearWeb.Repositories
{
    public class InstructorRepo : IInstructorRepo
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

        private IQueryable<TblInstructor> _tblInstructors;
        public IQueryable<TblInstructor> TblInstructors
        {
            get
            {
                _tblInstructors = _tblInstructors ?? DataContext.Instructors.Select(s => new TblInstructor {Email = s.Email , FirstName = s.FirstName,LastName = s.LastName, InstructorId = s.InstructorId, Mobile = s.Mobile.ToString(), Phone = s.Phone.ToString()});
                return _tblInstructors;
            }
            set { _tblInstructors = value; }
        }

        public async Task<IList<TblInstructor>> GetInstructorList()
        {
            return await TblInstructors.ToListAsync();
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