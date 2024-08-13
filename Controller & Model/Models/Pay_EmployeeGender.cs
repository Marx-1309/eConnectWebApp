using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eConnectWebApp.Models.ViewModels
{
    public class Pay_EmployeeGender
    {
        [Key]
        public System.Int64 EmployeeGenderID {  get; set; }
        public string EmployeeGender { get; set; }
    }
}