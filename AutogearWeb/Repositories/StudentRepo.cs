﻿using System;
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

        public AutogearDBEntities DataContext { get; set; }

        public StudentRepo()
        {
            DataContext = new AutogearDBEntities();
        }

        private IQueryable<TblStudent> _tblStudents;
        public IQueryable<TblStudent> TblStudents
        {
            get
            {

                 _tblStudents = _tblStudents ??
                     (from student in DataContext.Students
                        let instructorStudent =
                            DataContext.Instructor_Student.FirstOrDefault(s => s.StudentId == student.Id)
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

        public async Task<IList<string>> GetStudentNames()
        {
            return await TblStudents.Select(s => s.FirstName + " " + s.LastName).ToListAsync();
        }

        public void SaveStudentAppointment(BookingAppointment bookingAppointment, string currentUser)
        {
            var bookingDetails =
                DataContext.Bookings.FirstOrDefault(s => s.BookingId == bookingAppointment.BookingId) ?? new Booking();
            var studentDetails =
                TblStudents.FirstOrDefault(s => (s.FirstName + " " + s.LastName) == bookingAppointment.StudentName);
            if (studentDetails != null)
            {
                bookingDetails.InstructorId = currentUser;
                bookingDetails.BookingDate = DateTime.Now;
                bookingDetails.StartTime = bookingAppointment.StartTime;
                bookingDetails.EndTime = bookingAppointment.StopTime;
                bookingDetails.Status = "Learning";
                bookingDetails.StudentId = studentDetails.StudentId;
                bookingDetails.CreatedBy = currentUser;
                bookingDetails.CreatedDate = DateTime.Now;
                bookingDetails.StartDate = bookingAppointment.StartDate;
                bookingDetails.EndDate = bookingAppointment.EndDate;
                if (bookingAppointment.BookingId == 0)
                    DataContext.Bookings.Add(bookingDetails);
                DataContext.SaveChanges();
            }
        }
        public void SaveStudent(StudentModel studentModel,string currentUser)
        {
            if (currentUser != null)
            {
                // Student Creation
                var student = new Student
                {
                    FirstName = studentModel.FirstName,
                    Email = studentModel.Email,
                    LastName = studentModel.LastName,
                    Gender = studentModel.Gender,
                    Status = studentModel.Status,
                    CreatedBy = currentUser,
                    CreatedDate = DateTime.Now,
                    StartDate = studentModel.StartDate,
                };
                DataContext.Students.Add(student);
                DataContext.SaveChanges();
                //License Information
                var studentLicense = new Student_License
                {
                    StudentId = student.Id,
                    ExpiryDate = Convert.ToDateTime(studentModel.ExpiryDate),
                    StateId = studentModel.StateId,
                    Class = studentModel.ClassName,
                    LicenseNo = studentModel.LicenseNumber,
                    License_passed_Date =studentModel.LicensePassedDate,
                    Remarks = studentModel.Remarks
                };
                DataContext.Student_License.Add(studentLicense);
                DataContext.SaveChanges();
                if (!string.IsNullOrEmpty(studentModel.InstructorName))
                {
                    var instructor =
                        DataContext.Instructors.SingleOrDefault(
                            s => (s.FirstName + " " + s.LastName) == studentModel.InstructorName);
                    // Booking Information
                    if (instructor != null)
                    {

                        //Save instructor student
                        var instructorStudent = new Instructor_Student
                        {
                            InstructorId = instructor.InstructorId,
                            StudentId = student.Id,
                            CreatedBy = currentUser,
                            CreatedDate = DateTime.Now,
                            
                        };
                        DataContext.Instructor_Student.Add(instructorStudent);
                        DataContext.SaveChanges();
                        var studentBooking = new Booking
                        {
                            StudentId = student.Id,
                            PackageId = studentModel.PackageId,
                            CreatedDate = DateTime.Now,
                            BookingDate = DateTime.Now,
                            StartDate = studentModel.BookingStartDate,
                            EndDate = studentModel.BookingEndDate,
                            InstructorId = instructor.InstructorId,
                            StartTime = studentModel.StartTime,
                            EndTime = studentModel.StopTime,
                            Discount = studentModel.PackageDisacount,
                            PickupLocation = studentModel.PickupLocation,
                            DropLocation = studentModel.DropLocation,
                            CreatedBy = currentUser,
                            Type = "Learning"
                        };
                        DataContext.Bookings.Add(studentBooking);
                        DataContext.SaveChanges();
                        // Driving Test Information
                        var studentDrivingBooking = new Booking
                        {
                            StudentId = student.Id,
                            PackageId = studentModel.DrivingTestPackageId,
                            CreatedDate = DateTime.Now,
                            BookingDate = studentModel.DrivingTestDate,
                            InstructorId = instructor.InstructorId,
                            StartTime = studentModel.DrivingTestStartTime,
                            EndTime = studentModel.DrivingTestStopTime,
                            Discount = studentModel.DrivingTestPackageDisacount,
                            PickupLocation = studentModel.DrivingTestPickupLocation,
                            DropLocation = studentModel.DrivingTestDropLocation,
                            CreatedBy = currentUser,
                            Type = "Driving"
                        };
                        DataContext.Bookings.Add(studentDrivingBooking);
                        DataContext.SaveChanges();
                    }
                   
                }
            }
        }
    }
}