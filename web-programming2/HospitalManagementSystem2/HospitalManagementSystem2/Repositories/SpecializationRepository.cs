using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HospitalManagementSystem2.Repositories
{
    public class SpecializationRepository : BaseRepository<Specialization>
    {
        public SpecializationRepository() : base(new HospitalSystemDbContext())
        {
        }
        public SpecializationRepository(HospitalSystemDbContext context) : base(context)
        {
        }


        //public IQueryable<Specialization> AddToDoctor   (int doctorId,
        //    Expression<Func<Specialization, bool>> filter,
        //    int page = 1, int itemsPerPage = int.MaxValue,
        //    Func<IQueryable<Specialization>, IOrderedQueryable<Specialization>> OrderbyDescending = null)
        //{
        //    HospitalSystemDbContext context = new HospitalSystemDbContext();
        //    IQueryable<Specialization> result = context.Specializations.Where(pl => pl.Doctors.Any(u => u.Id == doctorId));

        //    if (filter != null)
        //        result = result.Where(filter);

        //    if (OrderbyDescending == null)
        //        OrderbyDescending = i => i.OrderBy(x => x.Id);

        //    result = OrderbyDescending(result);

        //    return result;
        //}

    }
}