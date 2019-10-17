using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.Entities
{
    public class Patient : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phonenumber { get; set; }
        public string AccountType { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<PatientDiagnosis> PatientDiagnoses { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }





    }
}