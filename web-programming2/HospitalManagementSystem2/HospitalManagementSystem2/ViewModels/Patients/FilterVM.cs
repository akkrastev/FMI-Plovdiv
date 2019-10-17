using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.ViewModels.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Patients
{
    public class FilterVM : BaseFilterVM<Patient>
    {
        [DisplayName("Username:")]
        public string Username { get; set; }
        [DisplayName("First Name:")]
        public string FirstName { get; set; }
        [DisplayName("Last Name:")]
        public string LastName { get; set; }
        [DisplayName("Phone Number:")]
        public string PhoneNumber { get; set; }

        public override Expression<Func<Patient, bool>> GenerateFilter()
        {
            return i => (string.IsNullOrEmpty(Username) || i.Username.Contains(Username)) &&
                        (string.IsNullOrEmpty(FirstName) || i.FirstName.Contains(FirstName)) &&
                        (string.IsNullOrEmpty(LastName) || i.LastName.Contains(LastName)) &&
                        (string.IsNullOrEmpty(PhoneNumber) || i.Phonenumber.Contains(PhoneNumber));
        }

    }
}
