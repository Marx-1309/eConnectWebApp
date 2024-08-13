using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eConnectWebApp.Models
{
    public class HR2DIV02
    {
        
        [Key]
        public string DIVISIONCODE_I { get; set; }  //   NOT NULL
        public string COMPANYCODE_I { get; set; }  //   NOT NULL
        public string DIVISION_I { get; set; }      //   NOT NULL
        public string ADDRESS1 { get; set; }        //   NOT NULL
        public string ADDRESS2 { get; set; }        //   NOT NULL
        public string CITY { get; set; }            //   NOT NULL
        public string STATE { get; set; }           //   NOT NULL
        public string ZIPCODE_I { get; set; }       //   NOT NULL
        public string PHONE10_I { get; set; }       //   NOT NULL
        public string EXT_I { get; set; }           //   NOT NULL
        public string FAXNUMBERI_I { get; set; }    //   NOT NULL
        public string EMAILADDRESS_I { get; set; }  //   NOT NULL
        public decimal NOTESINDEX_I { get; set; }   // [numeric](19, 5) NOT NULL
        public string CHANGEBY_I { get; set; }      //   NOT NULL
        public DateTime CHANGEDATE_I { get; set; }  // [datetime] NOT NULL
        public int DEX_ROW_ID { get; set; }         // [int] IDENTITY(1,1) NOT NULL
    }
}