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

        public AutogearDBEntities DataContext { get; set; }

        public  InstructorRepo()
        {
            DataContext = new AutogearDBEntities();
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

        public async Task<IList<string>> GetInstructorNames()
        {
            return await TblInstructors.Select(s => s.FirstName + " " + s.LastName).ToListAsync();
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