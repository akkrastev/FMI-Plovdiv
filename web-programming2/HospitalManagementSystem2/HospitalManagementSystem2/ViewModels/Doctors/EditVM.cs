using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.ViewModels.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Doctors
{
    public class EditVM : BaseEditVM<Doctor>
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

        public string AccountType { get; set; }

        public bool IsAdmin { get; set; }

        public override void PopulateModel(Doctor item)
        {
            Id = item.Id;
            Username = item.Username;
            Password = item.Password;
            FirstName = item.FirstName;
            LastName = item.LastName;
            AccountType = "Doctor";
            IsAdmin = item.IsAdmin;
        }

        public override void PopulateEntity(Doctor item)
        {
            item.Id = Id;
            item.Username = Username;
            item.Password = Password;
            item.FirstName = FirstName;
            item.LastName = LastName;
            item.AccountType = "Doctor";
            item.IsAdmin = IsAdmin;
        }
    }
}