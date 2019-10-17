using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.Entities
{
    public class Medicine : BaseEntity
    {
        public string MedicineName { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}