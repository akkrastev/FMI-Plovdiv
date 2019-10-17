using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Doctors
{
    public class SpecializationVM
    {
        public Doctor doctor { get; set; }

        public IQueryable<Specialization> specialization { get; set; }
    }
}