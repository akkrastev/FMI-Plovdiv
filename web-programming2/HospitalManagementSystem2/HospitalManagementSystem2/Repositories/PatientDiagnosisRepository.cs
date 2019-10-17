using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagementSystem2.Entities;

namespace HospitalManagementSystem2.Repositories
{
    public class PatientDiagnosisRepository : BaseRepository<PatientDiagnosis>
    {
        public PatientDiagnosisRepository() : base(new HospitalSystemDbContext())
        {
        }
        public PatientDiagnosisRepository(HospitalSystemDbContext context) : base(context)
        {
        }
    }
}