//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutogearWeb.EFModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int StudentId { get; set; }
        public string InstructorId { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public string PickupLocation { get; set; }
        public string DropLocation { get; set; }
        public Nullable<int> PackageId { get; set; }
        public string Discount { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> CancelledDate { get; set; }
        public string CancelledReason { get; set; }
        public string Type { get; set; }
        public Nullable<int> RTAId { get; set; }
        public string DrivingTestStatus { get; set; }
        public Nullable<int> DrivingTestAttempt { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual AspNetUser AspNetUser1 { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual Package_Details Package_Details { get; set; }
        public virtual RTA RTA { get; set; }
        public virtual Student Student { get; set; }
    }
}
