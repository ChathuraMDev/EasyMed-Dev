using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels
{
    public class UserDataViewModel
    {
        public int numUserId { get; set; }
        public string txtUserName { get; set; }
        public string txtPassword { get; set; }
        public string chrRole { get; set; }
        public string txtFName { get; set; }
        public string txtMName { get; set; }
        public string txtLName { get; set; }
        public string txtTitle { get; set; }
        public string txtContactNo { get; set; }
        public string txtEmail { get; set; }
        public string txtFax { get; set; }
        public string txtAddress1 { get; set; }
        public string txtAddress2 { get; set; }
        public string txtAddress3 { get; set; }
        public string txtQualification { get; set; }
        public bool bolStatus { get; set; }
        public bool userAuth { get; set; }
    }
}
