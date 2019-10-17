using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.ViewModels.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Medicines
{
    public class FilterVM : BaseFilterVM<Medicine>
    {
        [DisplayName("Medicine Name:")]
        public string MedicineName { get; set; }

        public override Expression<Func<Medicine, bool>> GenerateFilter()
        {
            return s => (string.IsNullOrEmpty(MedicineName) || s.MedicineName.Contains(MedicineName));
        }
    }
}