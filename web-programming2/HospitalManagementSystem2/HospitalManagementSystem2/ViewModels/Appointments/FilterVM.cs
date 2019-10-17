using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Appointments
{
    public class FilterVM
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public DateTime? AppointmentDate { get; set; }



        public Expression<Func<Appointment, bool>> GenerateFilter()
        {

            //  return i => ( (AppointmentDate == null)|| i.AppointmentDate.ToString().Contains(AppointmentDate.ToString())) &&
            //     (i.PatientId == PatientId) && (i.DoctorId == DoctorId);
            return null;
        }
    }
}