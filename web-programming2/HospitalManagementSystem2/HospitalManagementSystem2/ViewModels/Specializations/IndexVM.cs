using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.ViewModels.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Specializations
{
    public class IndexVM : BaseIndexVM<Specialization,FilterVM>
    {

       

        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
    }
}