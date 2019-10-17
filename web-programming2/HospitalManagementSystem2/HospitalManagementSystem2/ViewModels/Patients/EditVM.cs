using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.ViewModels.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Patients
{
    public class EditVM : BaseEditVM<Patient>
    {
        public int Id { get; set; }
        [DisplayName("Username:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Username { get; set; }
        [DisplayName("Password:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Password { get; set; }
        [DisplayName("First Name:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string FirstName { get; set; }
        [DisplayName("Last Name:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string LastName { get; set; }

        
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        public string AccountType { get; set; }

        public override void PopulateModel(Patient item)
        {
            Id = item.Id;
            Username = item.Username;
            Password = item.Password;
            FirstName = item.FirstName;
            LastName = item.LastName;
            PhoneNumber = item.Phonenumber;
            AccountType = "Patient";
            
        }

        public override void PopulateEntity(Patient item)
        {
            item.Id = Id;
            item.Username = Username;
            item.Password = Password;
            item.FirstName = FirstName;
            item.LastName = LastName;
            item.Phonenumber = PhoneNumber;
            item.AccountType = "Patient";
            
        }
    }
}