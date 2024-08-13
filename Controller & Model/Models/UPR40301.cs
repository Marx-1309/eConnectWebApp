using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eConnectWebApp.Models
{
    public class UPR40301
    {
        [Key]
        public string JOBTITLE { get; set; }              //   NOT NULL
        public string DSCRIPTN { get; set; }              //   NOT NULL
        public short EEOCLASS_I { get; set; }             // [smallint] NOT NULL
        public short FLSASTATUS { get; set; }             // [smallint] NOT NULL
        public string REPORTSTOPOS { get; set; }          //   NOT NULL
        public string REVIEWSETUPCODE_I { get; set; }     //   NOT NULL
        public int SKILLSETNUMBER_I { get; set; }         // [int] NOT NULL
        public string CHANGEBY_I { get; set; }            //   NOT NULL
        public DateTime CHANGEDATE_I { get; set; }        // [datetime] NOT NULL
        public decimal NOTEINDX { get; set; }             // [numeric](19, 5) NOT NULL
        public decimal NOTEINDX2 { get; set; }            // [numeric](19, 5) NOT NULL
        public int DEX_ROW_ID { get; set; }               // [int] IDENTITY(1,1) NOT NULL
        public string TXTFIELD { get; set; }              // [text] NOT NULL
    }
}