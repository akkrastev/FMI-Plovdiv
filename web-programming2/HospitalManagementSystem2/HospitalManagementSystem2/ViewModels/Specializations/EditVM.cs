using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.ViewModels.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Specializations
{
    public class EditVM : BaseEditVM<Specialization>
    {

        public int Id { get; set; }    
        [DisplayName("Specialization name:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string SpecializationName { get; set; }
        public List<int> DoctorIds { get; set; }
        public  Specialization specialization { get; set; }

        public List<Doctor> Doctors { get; set; }
        public override void PopulateModel(Specialization item)
        {
            Id = item.Id;
            SpecializationName = item.SpecializationName;
        }

        public override void PopulateEntity(Specialization item)
        {
            item.Id = Id;
            item.SpecializationName = SpecializationName;
            
        }
    }
}