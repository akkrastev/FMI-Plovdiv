using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.Services
{
    public class AuthenticationService
    {
        public Doctor LoggedDoctor { get; private set; }
        public Patient LoggedPatient { get; private set; }

        public void AuthenticateDoctor(string username, string password)
        {
            DoctorRepository doctorRepo = new DoctorRepository();
            LoggedDoctor = doctorRepo.GetAll(u => u.Username == username && u.Password == password).FirstOrDefault();
        }
        public void AuthenticatePatient(string username, string password)
        {
            PatientRepository patientRepo = new PatientRepository();
            LoggedPatient = patientRepo.GetAll(u => u.Username == username && u.Password == password).FirstOrDefault();
        }
    }
}