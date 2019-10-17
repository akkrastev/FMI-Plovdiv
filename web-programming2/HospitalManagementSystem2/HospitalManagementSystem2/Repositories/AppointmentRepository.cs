using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>
    {
        public AppointmentRepository() : base(new HospitalSystemDbContext())
        {
        }
        public AppointmentRepository(HospitalSystemDbContext context) : base(context)
        {
        }
    }
}