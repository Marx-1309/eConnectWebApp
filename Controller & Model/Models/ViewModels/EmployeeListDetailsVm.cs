using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eConnectWebApp.Models.ViewModels
{
    public class EmployeeListDetailsVm :EmployeeVm
    {
        [Key]
        public string EMPLOYID { get; set; }
        public string LASTNAME { get; set; } = "";
        public string FRSTNAME { get; set; } = "";
        public string GENDER { get; set; }
        public string SOCSCNUM { get; set; }
    }
}