using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.Repositories
{
    public class PatientRepository : BaseRepository<Patient>
    {
        public PatientRepository() : base(new HospitalSystemDbContext())
        {
        }
        public PatientRepository(HospitalSystemDbContext context) : base(context)
        {
        }
        public IQueryable<Medicine> GetMedicineByPatientId(int patientId)
        {
            HospitalSystemDbContext context = new HospitalSystemDbContext();
            IQueryable<Medicine> result = context.Medicines.Where(pl => pl.Patients.Any(u => u.Id == patientId));

            return result;
        }
    }
}