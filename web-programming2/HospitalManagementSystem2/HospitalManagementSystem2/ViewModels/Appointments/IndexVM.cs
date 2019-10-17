using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.ViewModels.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Appointments
{
    public class IndexVM
    {
        public PagerVM Pager { get; set; }
        public FilterVM Filter { get; set; }

        public List<Appointment> items { get; set; }


        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public List<Patient> PatientList { get; set; }

        public List<Doctor> DoctorList { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }


    }
}