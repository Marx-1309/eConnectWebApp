using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eConnectWebApp.Models.ViewModels
{
    public class Pay_EmployeeMaritalStatus
    {
        [Key]
        public System.Int64 EmployeeMaritalStatusID { get; set; }
        public string EmployeeMaritalStatus{ get; set; }
    }
}