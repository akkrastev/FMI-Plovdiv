using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.Repositories
{
    public class HospitalSystemDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<PatientDiagnosis> PatientDiagnoses { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        

        public HospitalSystemDbContext()
            : base("HospitalSystemDbConnection")
        {
            this.Patients = this.Set<Patient>();
            this.Doctors = this.Set<Doctor>();
            this.PatientDiagnoses = this.Set<PatientDiagnosis>();
            this.Appointments = this.Set<Appointment>();
            this.Specializations = this.Set<Specialization>();
            this.Medicines = this.Set<Medicine>();

        }
    }
}