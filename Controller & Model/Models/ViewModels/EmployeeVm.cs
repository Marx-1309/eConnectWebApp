using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eConnectWebApp.Models.ViewModels
{
    public class EmployeeVm 
    {
        [Key]
        public string EMPLOYID { get; set; } = Guid.NewGuid().ToString();                   // Disabled input with ID "addEMPLOYID"
        public int? EmployeeTypeID { get; set; } = 0;              // For select element with ID "addEmployeeTypeID"
        public string LASTNAME { get; set; } = "";                    // Input with ID "addLASTNAME"
        public string FRSTNAME { get; set; } = "";                    // Input with ID "addFRSTNAME"
        public string MIDLNAME { get; set; } = "";                     // Input with ID "addMIDLNAME"
        public string SOCSCNUM { get; set; } = "";                       // Input with ID "addSOCSCNUM"
        public string ADRSCODE { get; set; } = "";                // Input with ID "addADRSCODE"
        public string ADDRESS1 { get; set; } = "";                     // Input with ID "addADDRESS1"
        public string ADDRESS2 { get; set; } = "";                     // Input with ID "addADDRESS2"
        public string ADDRESS3 { get; set; } = "";                  // Input with ID "addADDRESS3"
        public string PHONE1 { get; set; } = "";                    // Input with ID "addPHONE1"
        public string BRTHDATE { get; set; } = "";                  // Date input with ID "addBRTHDATE"
        public int? EmployeeGenderID { get; set; } = 0;                  // For select element with ID "addEmployeeGenderID"
        public string DIVISIONCODE { get; set; } = "";                 // For select element with ID "addDIVISIONCODE"
        public string DEPRTMNT { get; set; } = "";                  // For select element with ID "addDEPRTMNT"
        public string JOBTITLE { get; set; } = "";                   // For select element with ID "addJOBTITLE"
        public string STRTDATE { get; set; } = "";                   // Date input with ID "addSTRTDATE"
        public short WKHRPRYR { get; set; } = 0;                 // Input with ID "addWKHRPRYR"
        public int? EmployeeMaritalStatusID { get; set; } = 0;       // For select element with ID "addEmployeeMaritalStatusID"
        public string LASTDAYWORKED { get; set; } = "";               // Date input with ID "addLASTDAYWORKED"
        public string TerminationReason { get; set; } = "";           // Input with ID "addTerminationReason"
        public int INACTIVE { get; set; } = 0;        // For select element with ID "addINACTIVE"
        public string CITY { get; set; } = "";
        public string ZIPCODE { get; set; } = "";
        public string EMPLCLAS { get; set; } = "";
        public string EMPLSUFF { get; set; } = "";
        public string STATE { get; set; } = "";
        public string COUNTY { get; set; } = "";
        public string COUNTRY { get; set; } = "";
        public string PHONE2 { get; set; } = "";
        public string PHONE3 { get; set; } = "";
        public string FAX { get; set; } = "";
        public int? GENDER { get; set; } = 3;
        public int? ETHNORGN { get; set; } = 7;
        public string DIVISIONCODE_I { get; set; } = "";
        public string SUPERVISORCODE_I { get; set; } = "";
        public string LOCATNID { get; set; } = "";
        public int? WCACFPAY { get; set; } = 0;
        public string AccountNumber { get; set; } = "";
        public string DEMPINAC { get; set; } = "";
        public string RSNEMPIN { get; set; } = "";
        public string SUTASTAT { get; set; } = "";
        public string WRKRCOMP { get; set; } = "";
        public int? STMACMTH { get; set; } = 0;
        public string USERDEF1 { get; set; } = "";
        public string USERDEF2 { get; set; } = "";
        public int? MARITALSTATUS { get; set; } = 3;
        public string BENADJDATE { get; set; } = "";
        public string LASTDAYWORKED_I { get; set; } = "";
        public int? BIRTHDAY { get; set; } = 0;
        public int? BIRTHMONTH { get; set; } = 0;
        public string SPOUSE { get; set; } = "";
        public string SPOUSESSN { get; set; } = "";
        public string NICKNAME { get; set; } = "";
        public string ALTERNATENAME { get; set; } = "";
        public string STATUSCD { get; set; } = "";
        public int? HRSTATUS { get; set; } = 1;
        public string DATEOFLASTREVIEW_I { get; set; } = "";
        public string DATEOFNEXTREVIEW_I { get; set; } = "";
        public string BENEFITEXPIRE_I { get; set; } = "";
        public int? HANDICAPPED { get; set; } = 0;
        public int? VETERAN { get; set; } = 0;
        public int? VIETNAMVETERAN { get; set; } = 0;
        public int? DISABLEDVETERAN { get; set; } = 0;
        public int? UNIONEMPLOYEE { get; set; } = 0;
        public int? SMOKER_I { get; set; } = 0;
        public int? CITIZEN { get; set; } = 0;
        public int? VERIFIED { get; set; } = 0;
        public string I9RENEW { get; set; } = "";
        public string Primary_Pay_Record { get; set; } = "";
        public string CHANGEBY_I { get; set; } = "";
        public string CHANGEDATE_I { get; set; } = "";
        public string UNIONCD { get; set; } = "";
        public string RATECLSS { get; set; } = "";
        public string FEDCLSSCD { get; set; } = "";
        public int? OTHERVET { get; set; } = 0;
        public string Military_Discharge_Date { get; set; } = "";
        public int? DefaultFromClass { get; set; } = 0;
        public int? UpdateIfExists { get; set; } = 1;
        public int? RequesterTrx { get; set; } = 0;
        public string USRDEFND1 { get; set; } = "";
        public string USRDEFND2 { get; set; } = "";
        public string USRDEFND3 { get; set; } = "";
        public string USRDEFND4 { get; set; } = "";
        public string USRDEFND5 { get; set; } = "";


        //public List<Pay_EmployeeGender> Pay_EmployeeGender { get; set; }
        //public List<Pay_EmployeeMaritalStatus> Pay_EmployeeMaritalStatus { get; set; }
        //public List<Pay_EmployeeMaritalStatus> Pay_EmpmarStatus { get; set; }
    }
}