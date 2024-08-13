using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eConnectWebApp.Data
{
    public class eConnectWebAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public eConnectWebAppContext() : base("name=eConnectWebAppContext")
        {
        }

        public System.Data.Entity.DbSet<eConnectWebApp.Models.ViewModels.EmployeeVm> Pay_Employees { get; set; }
        //public System.Data.Entity.DbSet<eConnectWebApp.Models.Pay_Employee> UPR00100 { get; set; }
        public System.Data.Entity.DbSet<eConnectWebApp.Models.ViewModels.Pay_EmployeeGender> Pay_EmployeeGender { get; set; }
        public System.Data.Entity.DbSet<eConnectWebApp.Models.ViewModels.Pay_EmployeeMaritalStatus> Pay_EmployeeMaritalStatus { get; set; }
        public System.Data.Entity.DbSet<eConnectWebApp.Models.ViewModels.Pay_EmployeeType> Pay_EmployeeType { get; set; }
        public System.Data.Entity.DbSet<eConnectWebApp.Models.UPR40300> Gp_Department { get; set; }
        public System.Data.Entity.DbSet<eConnectWebApp.Models.HR2DIV02> Gp_DivisionCode { get; set; }
        public System.Data.Entity.DbSet<eConnectWebApp.Models.UPR40301> Gp_JobTitle { get; set; }

        public System.Data.Entity.DbSet<eConnectWebApp.Models.ViewModels.EmployeeListDetailsVm> EmployeeListDetailsVms { get; set; }
    }
}
