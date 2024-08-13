using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eConnectWebApp.Models.ViewModels
{
    public class Pay_EmployeeType
    {
        [Key]
        public System.Int64 EmployeeTypeID {  get; set; }
        public string EmployeeType { get; set; }
    }
}