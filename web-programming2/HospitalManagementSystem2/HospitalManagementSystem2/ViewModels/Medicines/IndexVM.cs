using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.ViewModels.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Medicines
{
    public class IndexVM : BaseIndexVM<Medicine,FilterVM>
    {

        public Patient Patient { get; set; }
        public int PatientId { get; set; }
    }
}