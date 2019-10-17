using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.Repositories
{
    public class MedicineRepository : BaseRepository<Medicine>
    {
        public MedicineRepository() : base(new HospitalSystemDbContext())
        {
        }
        public MedicineRepository(HospitalSystemDbContext context) : base(context)
        {
        }
    }
}