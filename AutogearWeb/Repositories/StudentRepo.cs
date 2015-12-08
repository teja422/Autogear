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
    public class StudentRepo : IStudentRepo
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public autogearEntities DataContext { get; set; }

        public StudentRepo()
        {
            DataContext = new autogearEntities();
        }

        private IQueryable<TblStudent> _tblStudents;
        public IQueryable<TblStudent> TblStudents
        {
            get
            {

                 _tblStudents = _tblStudents ??
                     (from student in DataContext.Students
                        let instructorStudent =
                            DataContext.Instructor_Student.SingleOrDefault(s => s.StudentId == student.Id)
                        where instructorStudent != null
                        select new TblStudent
                        {
                            StudentId = student.Id,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            Gender = student.Gender,
                            StartDate = student.StartDate,
                            Status = student.Status,
                            InstructorName = instructorStudent.Instructor.FirstName
                        });
                return _tblStudents;

            }
            set { _tblStudents = value; }
        }

        private IQueryable<TblStudentAddress> _tblStudentAddresses;
        public IQueryable<TblStudentAddress> TblStudentAddresses
        {
            get
            {
                _tblStudentAddresses = _tblStudentAddresses ??
                                       DataContext.Student_Address.Select(s => new TblStudentAddress {Address1 = s.AddressLine1,Address2 = s.AddressLine2 , Mobile = s.Mobile, AddressId = s.AddressId ,Phone = s.Phone ,PostalCode = s.PostCode,StudentId = s.StudentId, SuburbId = s.SuburbID});
                return _tblStudentAddresses;
            }
            set { _tblStudentAddresses = value; }
        }

        private IQueryable<TblStudentLicense> _tblStudentLicenses;
        public IQueryable<TblStudentLicense> TblStudentLicenses
        {
            get
            {
                _tblStudentLicenses = _tblStudentLicenses ??
                    DataContext.Student_License.Select(
                        s =>
                            new TblStudentLicense
                            {
                                StudentId = s.StudentId,
                                ClassName = s.Class,
                                ExpiryDate = s.ExpiryDate,
                                Id = s.Id,
                                LicenseNumber = s.LicenseNo,
                                LicensePassedDate = s.License_passed_Date,
                                Remarks = s.Remarks
                            });
                return _tblStudentLicenses;
            }
            set { _tblStudentLicenses = value; }
        }

        private IQueryable<TblBooking> _tblBookings;
        public IQueryable<TblBooking> TblStudentBookings
        {
            get { _tblBookings = _tblBookings ?? DataContext.Bookings.Select(s => new TblBooking {BookingId = s.BookingId, BookingDate = s.BookingDate , DropLocation = s.DropLocation, PickupLocation = s.PickupLocation , PackageId= s.PackageId, StartTime = s.StartTime, StopTime = s.EndTime,InstructorId = s.InstructorId, StudentId = s.StudentId});
                return _tblBookings;
            }
            set { _tblBookings = value;  }
        }

        private IQueryable<TblPackage> _tblPackages;
        public IQueryable<TblPackage> TblPackageDetails
        {
            get
            {
                _tblPackages = _tblPackages ?? DataContext.Package_Details.Select(s => new TblPackage {PackageId = s.PackageId, PackageDescription = s.Description, PackageName = s.Name});
                return _tblPackages;
            }
            set { _tblPackages = value; }
        }

        private IQueryable<TblState> _tblStateses;

        public IQueryable<TblState> TblStates
        {
            get
            {
                _tblStateses = _tblStateses ??
                               DataContext.States.Select(
                                   s => new TblState {StateId = s.StateId, StateName = s.State_Name});
                return _tblStateses;
            }
            set { _tblStateses = value; }
        }

        public async Task<List<TblStudent>> GetStudentList()
        {
            return await TblStudents.ToListAsync();
        }

        public IList<SelectListItem> GetPackages()
        {
            return TblPackageDetails.Select(s => new SelectListItem { Text = s.PackageName , Value = s.PackageId.ToString()}).ToList();
        }

        public IList<SelectListItem> GetStateList()
        {
            return TblStates.Select(s => new SelectListItem {Text = s.StateName, Value = s.StateId.ToString()}).ToList();
        }
    }
}