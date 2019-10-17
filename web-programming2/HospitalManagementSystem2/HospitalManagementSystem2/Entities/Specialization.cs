using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.Entities
{
    public class Specialization : BaseEntity
    {
        public string SpecializationName { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}