using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.Repositories
{
    public class DoctorRepository : BaseRepository<Doctor>
    {
        public DoctorRepository() : base(new HospitalSystemDbContext())
        {
        }
        public DoctorRepository(HospitalSystemDbContext context) : base(context)
        {
        }

        public IQueryable<Specialization> GetSpecializationsByDoctorId(int doctorId)
        {
            HospitalSystemDbContext context = new HospitalSystemDbContext();
            IQueryable<Specialization> result = context.Specializations.Where(pl => pl.Doctors.Any(u => u.Id == doctorId));

            return result;
        }
    }
}