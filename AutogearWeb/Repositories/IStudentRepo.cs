﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutogearWeb.EFModels;
using AutogearWeb.Models;

namespace AutogearWeb.Repositories
{
    public interface IStudentRepo : IDisposable
    {
        AutogearDBEntities DataContext { get; set; }
        IQueryable<TblStudent> TblStudents { get; set; }
        IQueryable<TblStudentAddress> TblStudentAddresses { get; set; }
        IQueryable<TblStudentLicense> TblStudentLicenses { get; set; }
        IQueryable<TblBooking> TblStudentBookings { get; set; }
        IQueryable<TblPackage> TblPackageDetails { get; set; }
        IQueryable<TblState> TblStates { get; set; }
        
        Task<List<TblStudent>> GetStudentList();
        IList<SelectListItem> GetPackages();
        IList<SelectListItem> GetStateList();
        Task<IList<string>> GetStudentNames();
        void SaveStudentAppointment(BookingAppointment bookingAppointment, string currentUser);
        void SaveStudent(StudentModel studentModel,string currentUser);

    }
}
