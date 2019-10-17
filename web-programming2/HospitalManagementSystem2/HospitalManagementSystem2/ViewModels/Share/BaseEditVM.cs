using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Share
{
    public abstract class BaseEditVM<E>
        where E : BaseEntity, new()
    {
        public abstract void PopulateModel(E item);
        public abstract void PopulateEntity(E item);
    }
}