using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.ViewModels.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem2.ViewModels.Appointments
{
    public class EditVM 
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }


        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        [DisplayName("Patient: ")]
        public int SelectedPatient { get; set; }
        public List<SelectListItem> PatientsList { get; set; }


        [Required]
        [Display(Name = "Date for Appointment")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AppointmentDate { get; set; }

        public EditVM() { }

        public EditVM(Appointment item)
        {
            Id = item.Id;
            SelectedPatient = item.PatientId;
            PatientId = item.PatientId;
            DoctorId = item.DoctorId;
            AppointmentDate = item.AppointmentDate;
            
        }

        public void PopulateEntity(Appointment item)
       {
            item.Id = Id;
            item.PatientId = SelectedPatient;
            item.DoctorId = DoctorId;
            item.AppointmentDate = AppointmentDate;
        }

    }
}