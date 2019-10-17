using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Patients
{
    public class MedicineVM
    {
        public Patient patient { get; set; }

        public IQueryable<Medicine> medicine { get; set; }
    }
}