using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eConnectWebApp.Models
{
    public class UPR40300
    {
        [Key]
        public string DEPRTMNT { get; set; }       //   NOT NULL
        public string DSCRIPTN { get; set; }       //   NOT NULL
        public string AddlDesc { get; set; }       //   NOT NULL
        public decimal NOTEINDX { get; set; }      // [numeric](19, 5) NOT NULL
        public string CHANGEBY_I { get; set; }     //   NOT NULL
        public DateTime CHANGEDATE_I { get; set; } // [datetime] NOT NULL
        public int DEX_ROW_ID { get; set; }        // [int] IDENTITY(1,1) NOT NULL
    }
}