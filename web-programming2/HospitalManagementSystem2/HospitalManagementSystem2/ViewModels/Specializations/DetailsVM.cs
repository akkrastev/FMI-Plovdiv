using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Specializations
{
    public class DetailsVM
    {
        public  Specialization specialization { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}