using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.ViewModels.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Medicines
{
    public class EditVM : BaseEditVM<Medicine>
    {
        public int Id { get; set; }
        [DisplayName("Medicine name:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string MedicineName { get; set; }
        public List<int> PatientIds { get; set; }
        public Medicine Medicines { get; set; }

        public List<Patient> Patients { get; set; }
        public override void PopulateModel(Medicine item)
        {
            Id = item.Id;
            MedicineName = item.MedicineName;
        }

        public override void PopulateEntity(Medicine item)
        {
            item.Id = Id;
            item.MedicineName = MedicineName;

        }
    }
}