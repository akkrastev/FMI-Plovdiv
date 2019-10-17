using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Share
{
    public abstract class BaseFilterVM<E>
     where E : BaseEntity
    {
        public abstract Expression<Func<E, bool>> GenerateFilter();
    }
}