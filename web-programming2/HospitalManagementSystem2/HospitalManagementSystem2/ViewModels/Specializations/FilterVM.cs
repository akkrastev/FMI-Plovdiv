using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.ViewModels.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Specializations
{
    public class FilterVM : BaseFilterVM<Specialization>
    {

        [DisplayName("Specialization Name:")]
        public string specializationName { get; set; }

        public override Expression<Func<Specialization, bool>> GenerateFilter()
        {
            return s => (string.IsNullOrEmpty(specializationName) || s.SpecializationName.Contains(specializationName));
        }
    }
}