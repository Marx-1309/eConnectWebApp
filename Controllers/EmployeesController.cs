using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Dynamics.GP.eConnect;
using Microsoft.Dynamics.GP.eConnect.Serialization;
using eConnectWebApp.Models;
using eConnectWebApp.Data;
using eConnectWebApp.Models.ViewModels;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace eConnectWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private eConnectWebAppContext db = new eConnectWebAppContext();
        string sqlConnectionString;
        string gpConnectionString;

        public EmployeesController()
        {
            sqlConnectionString = ConfigurationManager.ConnectionStrings["eConnectWebAppContext"].ConnectionString;
            gpConnectionString = @"data source=localhost;initial catalog=TWO;integrated security=SSPI;persist security info=False;packet size=4096"; 
        }
        // GET: Employees
        public ActionResult Index()
        {
            //EmployeeVm employeeVm = new EmployeeVm();
            //employeeVm.Pay_EmployeeGender = db.Pay_EmployeeGender.ToList();
            //employeeVm.Pay_EmployeeMaritalStatus = db.Pay_EmployeeMaritalStatus.ToList();
            //employeeVm.Pay_EmpmarStatus = db.Pay_EmployeeMaritalStatus.ToList();

            return View(GetEmployees());
        }

        public List<EmployeeListDetailsVm> GetEmployees()
        {
            ViewBag.GenderDropDown = db.Pay_EmployeeGender.ToList();
            ViewBag.MaritalStatusDropDown = db.Pay_EmployeeMaritalStatus.ToList();
            ViewBag.EmployeeTypeDropDown = db.Pay_EmployeeType.ToList();
            ViewBag.Gp_DepartmentDropDown = db.Gp_Department.ToList();
            ViewBag.Gp_DivisionCodeDropDown = db.Gp_DivisionCode.ToList();
            ViewBag.Gp_JobTitleDropDown = db.Gp_JobTitle.ToList();

            //string cs = ConfigurationManager.ConnectionStrings["eConnectWebAppContext"].ConnectionString;
            List<EmployeeListDetailsVm> employees = new List<EmployeeListDetailsVm>();
            using (SqlConnection con = new SqlConnection(sqlConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeListDetailsVm employee = new EmployeeListDetailsVm();

                    employee.EMPLOYID = rdr["EMPLOYID"].ToString();
                    employee.FRSTNAME = rdr["FRSTNAME"].ToString();
                    employee.LASTNAME = rdr["LASTNAME"].ToString();
                    employee.SOCSCNUM = rdr["SOCSCNUM"].ToString();
                    employee.GENDER = rdr["EmployeeGender"].ToString();

                    employees.Add(employee);
                }
                return employees;
            }
        }

        // GET: Employees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeVm employee = db.Pay_Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.GenderDropDown = db.Pay_EmployeeGender.ToList();
            ViewBag.MaritalStatusDropDown = db.Pay_EmployeeMaritalStatus.ToList();
            ViewBag.EmployeeTypeDropDown = db.Pay_EmployeeType.ToList();
            ViewBag.Gp_DepartmentDropDown = db.Gp_Department.ToList();
            ViewBag.Gp_DivisionCodeDropDown = db.Gp_DivisionCode.ToList();
            ViewBag.Gp_JobTitleDropDown = db.Gp_JobTitle.ToList();
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[STAThread]
        [HttpPost]
        public  JsonResult Create(EmployeeVm employee)
        {
            string sCustomerDocument;
            string sXsdSchema;
            string sConnectionString;

            using (eConnectMethods eConnectDbContext = new eConnectMethods())
            {
                try
                {
                    EmployeeVm employeeVm = new EmployeeVm();
                    var emp = db.Pay_EmployeeGender.ToList();
                    //employeeVm.Pay_EmployeeMaritalStatus = db.Pay_EmployeeMaritalStatus.ToList();
                    //employeeVm.Pay_EmpmarStatus = db.Pay_EmployeeMaritalStatus.ToList();
                    // Create the customer data file
                    //SerializeCustomerObject("Customer.xml");
                    string empNames = string.Concat(employee.FRSTNAME," ", employee.LASTNAME);
                    employee.EMPLOYID = GenerateUniqueClientCode(empNames);

                    SerializeEmployeeObject("Employee.xml", employee);

                    // Use an XML document to create a string representation of the customer
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load($"{Directory.GetCurrentDirectory()}\\Files_Store\\Employee\\Employee.xml");
                    sCustomerDocument = xmldoc.OuterXml;

                    // Specify the Microsoft Dynamics GP server and database in the connection string
                    //sConnectionString =  configuration.GetConnectionString("eConnectWebAppContext").ToString();

                    // Create an XML Document object for the schema
                    XmlDocument XsdDoc = new XmlDocument();

                    // Create a string representing the eConnect schema
                    sXsdSchema = XsdDoc.OuterXml;

                    // Pass in xsdSchema to validate against.
                    eConnectDbContext.CreateTransactionEntity(gpConnectionString, sCustomerDocument);
                    Dispose();
                    //Test2.Hello();
                }
                // The eConnectException class will catch eConnect business logic errors.
                // display the error message on the console
                catch (eConnectException exc)
                {
                    Console.Write(exc.ToString());
                }
                // Catch any system error that might occurr.
                // display the error message on the console
                catch (System.Exception ex)
                {
                    Console.Write(ex.ToString());
                }
                finally
                {
                    // Call the Dispose method to release the resources
                    // of the eConnectMethds object
                    eConnectDbContext.Dispose();
                }
                return null;
            } // end of using statement
        }

        public static void SerializeEmployeeObject(string filename, EmployeeVm empObj)
        {
            try
            {

                eConnectType eConnect = new eConnectType();
                // Instantiate a RMCustomerMasterType schema object
                UPRCreateEmployeeType employee = new UPRCreateEmployeeType();


                XmlSerializer serializer = new XmlSerializer(eConnect.GetType());

                var newCust = new taCreateEmployee
                {

                    EMPLOYID = empObj.EMPLOYID,
                    FRSTNAME = empObj.FRSTNAME,
                    LASTNAME = empObj.LASTNAME,
                    ADDRESS1 = empObj.ADDRESS1 ?? "",
                    ADRSCODE = empObj.ADRSCODE ?? "",
                    CITY = empObj.CITY ?? "",
                    ZIPCODE = empObj.ZIPCODE ?? "",
                    EMPLCLAS = empObj.EMPLCLAS ?? "",
                    INACTIVE = (short)empObj.INACTIVE,
                    MIDLNAME = empObj.MIDLNAME ?? "",
                    EMPLSUFF = empObj.EMPLSUFF ?? "",
                    ADDRESS2 = empObj.ADDRESS2 ?? "",
                    ADDRESS3 = empObj.ADDRESS3 ?? "",
                    STATE = empObj.STATE ?? "",
                    COUNTY = empObj.COUNTY ?? "",
                    COUNTRY = empObj.COUNTRY ?? "",
                    PHONE1 = empObj.PHONE1 ?? "",
                    PHONE2 = empObj.PHONE2 ?? "",
                    PHONE3 = empObj.PHONE3 ?? "",
                    FAX = empObj.FAX ?? "",
                    BRTHDATE = empObj.BRTHDATE ?? "",
                    GENDER = (short)empObj.EmployeeGenderID,
                    ETHNORGN = (short)empObj.ETHNORGN,
                    DIVISIONCODE_I = empObj.DIVISIONCODE_I ?? "",
                    SUPERVISORCODE_I = empObj.SUPERVISORCODE_I ?? "",
                    LOCATNID = empObj.LOCATNID ?? "",
                    WCACFPAY = (short)empObj.WCACFPAY,
                    AccountNumber = empObj.AccountNumber ?? "",
                    //WKHRPRYR = (short)empObj.WKHRPRYR,
                    STRTDATE = empObj.STRTDATE ?? "",
                    //DEMPINAC = empObj.DEMPINAC ?? "",
                    //RSNEMPIN = empObj.RSNEMPIN ?? "",
                    //SUTASTAT = empObj.SUTASTAT ?? "",
                    //WRKRCOMP = empObj.WRKRCOMP ?? "",
                    //STMACMTH = (short)empObj.STMACMTH,
                    //USERDEF1 = empObj.USRDEFND1 ?? "",
                    //USERDEF2 = empObj.USERDEF2 ?? "",
                    MARITALSTATUS = (short)empObj.MARITALSTATUS,
                    //BENADJDATE = empObj.BENADJDATE ?? "",
                    LASTDAYWORKED_I = empObj.LASTDAYWORKED_I ?? "",
                    //BIRTHDAY = (short)empObj.BIRTHDAY,
                    //BIRTHMONTH = (short)empObj.BIRTHMONTH,
                    //SPOUSE = empObj.SPOUSE ?? "",
                    //SPOUSESSN = empObj.SPOUSESSN ?? "",
                    //NICKNAME = empObj.NICKNAME ?? "",
                    //ALTERNATENAME = empObj.ALTERNATENAME ?? "",
                    STATUSCD = empObj.STATUSCD ?? "",
                    HRSTATUS = (short)empObj.HRSTATUS,
                    DATEOFLASTREVIEW_I = empObj.DATEOFLASTREVIEW_I ?? "",
                    DATEOFNEXTREVIEW_I = empObj.DATEOFNEXTREVIEW_I ?? "",
                    BENEFITEXPIRE_I = empObj.BENEFITEXPIRE_I ?? "",
                    HANDICAPPED = (short)empObj.HANDICAPPED,
                    VETERAN = (short)empObj.VETERAN,
                    VIETNAMVETERAN = (short)empObj.VIETNAMVETERAN,
                    DISABLEDVETERAN = (short)empObj.DISABLEDVETERAN,
                    UNIONEMPLOYEE = (short)empObj.UNIONEMPLOYEE,
                    SMOKER_I = (short)empObj.SMOKER_I,
                    CITIZEN = (short)empObj.CITIZEN,
                    VERIFIED = (short)empObj.VERIFIED,
                    I9RENEW = empObj.I9RENEW ?? "",
                    Primary_Pay_Record = empObj.Primary_Pay_Record ?? "",
                    CHANGEBY_I = empObj.CHANGEBY_I ?? "",
                    CHANGEDATE_I = empObj.CHANGEDATE_I ?? "",
                    UNIONCD = empObj.UNIONCD ?? "",
                    RATECLSS = empObj.RATECLSS ?? "",
                    FEDCLSSCD = empObj.FEDCLSSCD ?? "",
                    OTHERVET = (short)empObj.OTHERVET,
                    Military_Discharge_Date = empObj.Military_Discharge_Date ?? "",
                    DefaultFromClass = (short)empObj.DefaultFromClass,
                    UpdateIfExists = (short)(empObj.UpdateIfExists = 1),
                    RequesterTrx = (short)(empObj.RequesterTrx = 1),
                    USRDEFND1 = empObj.USERDEF1 ?? "",
                    USRDEFND2 = empObj.USRDEFND2 ?? "",
                    USRDEFND3 = empObj.USRDEFND3 ?? "",
                    USRDEFND4 = empObj.USRDEFND4 ?? "",
                    USRDEFND5 = empObj.USRDEFND5 ?? "",
                    SOCSCNUM = empObj.SOCSCNUM ?? "",
                    DEPRTMNT = empObj.DEPRTMNT ?? "" /*?? "SALE"*/,
                    JOBTITLE = empObj.JOBTITLE ?? "" /*?? "TEC"*/,
                    ATACRSTM = 1

                };



                employee.taCreateEmployee = newCust;
                UPRCreateEmployeeType[] myEmployeeMAster = { employee };

                eConnect.UPRCreateEmployeeType = myEmployeeMAster;
                var uploadsFolder = $"{Directory.GetCurrentDirectory()}\\Files_Store\\Employee\\";

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder,filename);

                FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
                XmlTextWriter writer = new XmlTextWriter(fs, new UTF8Encoding());

                serializer.Serialize(writer, eConnect);
                writer.Close();

            }
            catch (Exception ex)
            {

            }
        }

        private string GenerateUniqueClientCode(string name)
        {
            List<EmployeeListDetailsVm> employees = new List<EmployeeListDetailsVm>();
            List<EmployeeListDetailsVm> employeesIdList = new List<EmployeeListDetailsVm>();

            using (SqlConnection con = new SqlConnection(sqlConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeListDetailsVm employee = new EmployeeListDetailsVm();

                    employee.EMPLOYID = rdr["EMPLOYID"].ToString();

                    employees.Add(employee);
                }

                employeesIdList.AddRange(employees);
            }

            string[] words = name.Split(' ');
            if (words.Length >= 3)
            {
                string initials = string.Join("", words.Take(3).Select(word => word[0].ToString().ToUpper()));
                int count = 1;
                string clientCode;
                do
                {
                    clientCode = $"{initials}{count:D3}";
                    bool codeExists = employeesIdList.Any(c => c.EMPLOYID.Trim() == clientCode.Trim());
                    
                    if (!codeExists)
                    {
                        break;
                    }

                    count++;
                } while (true);

                return clientCode;
            }
            else
            {
                name = name.Replace(" ", "").ToUpper();
                while (name.Length < 3)
                {
                    name += 'A';
                }
                int count = 1;
                string clientCode;
                do
                {
                    clientCode = $"{name.Substring(0, 3)}{count:D3}";
                    bool codeExists = employeesIdList.Any(c => c.EMPLOYID.Trim() == clientCode.Trim());
                    if (!codeExists)
                    {
                        break;
                    }

                    count++;
                } while (true);

                return clientCode;
            }
        }
    }
}
