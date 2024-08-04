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

namespace eConnectWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private eConnectWebAppContext db = new eConnectWebAppContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[STAThread]
        [HttpPost]
        public  ActionResult Create(Employee empObject)
        {
            string sCustomerDocument;
            string sXsdSchema;
            string sConnectionString;

            using (eConnectMethods eConnectDbContext = new eConnectMethods())
            {
                try
                {
                    // Create the customer data file
                    //SerializeCustomerObject("Customer.xml");
                    SerializeEmployeeObject("Employee1.xml", empObject);

                    // Use an XML document to create a string representation of the customer
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load("Employee1.xml");
                    sCustomerDocument = xmldoc.OuterXml;

                    // Specify the Microsoft Dynamics GP server and database in the connection string
                    //sConnectionString =  configuration.GetConnectionString("eConnectWebAppContext").ToString();
                    sConnectionString = @"data source=localhost;initial catalog=TWO;integrated security=SSPI;persist security info=False;packet size=4096";

                    // Create an XML Document object for the schema
                    XmlDocument XsdDoc = new XmlDocument();

                    // Create a string representing the eConnect schema
                    sXsdSchema = XsdDoc.OuterXml;

                    // Pass in xsdSchema to validate against.
                    eConnectDbContext.CreateTransactionEntity(sConnectionString, sCustomerDocument);

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

        public static void SerializeEmployeeObject(string filename, Employee empObj)
        {
            try
            {

                eConnectType eConnect = new eConnectType();
                // Instantiate a RMCustomerMasterType schema object
                UPRCreateEmployeeType employee = new UPRCreateEmployeeType();
                UPRCreateEmployeeType uPRCreateEmployeeType = new UPRCreateEmployeeType();



                XmlSerializer serializer = new XmlSerializer(eConnect.GetType());

                var newCust = new taCreateEmployee
                {

                    EMPLOYID = empObj.EMPLOYID,
                    FRSTNAME = empObj.FRSTNAME,
                    LASTNAME = empObj.LASTNAME,
                    ADDRESS1 = empObj.ADDRESS1,
                    ADRSCODE = empObj.ADRSCODE,
                    CITY = empObj.CITY,
                    ZIPCODE = empObj.ZIPCODE,
                    EMPLCLAS = empObj.EMPLCLAS,
                    INACTIVE = 0,
                    MIDLNAME = empObj.MIDLNAME,
                    EMPLSUFF = empObj.EMPLSUFF,
                    ADDRESS2 = empObj.ADDRESS2,
                    ADDRESS3 = empObj.ADDRESS3,
                    STATE = empObj.STATE,
                    COUNTY = empObj.COUNTY,
                    COUNTRY = empObj.COUNTRY,
                    PHONE1 = empObj.PHONE1,
                    PHONE2 = empObj.PHONE2,
                    PHONE3 = empObj.PHONE3,
                    FAX = empObj.FAX,
                    BRTHDATE = empObj.BRTHDATE,
                    GENDER = (short)empObj.GENDER,
                    ETHNORGN = (short)empObj.ETHNORGN,
                    DIVISIONCODE_I = empObj.DIVISIONCODE_I,
                    SUPERVISORCODE_I = empObj.SUPERVISORCODE_I,
                    LOCATNID = empObj.LOCATNID,
                    WCACFPAY = (short)empObj.WCACFPAY,
                    AccountNumber = empObj.AccountNumber,
                    WKHRPRYR = (short)empObj.WKHRPRYR,
                    STRTDATE = empObj.STRTDATE,
                    DEMPINAC = empObj.DEMPINAC ?? "",
                    RSNEMPIN = empObj.RSNEMPIN,
                    SUTASTAT = empObj.SUTASTAT,
                    WRKRCOMP = empObj.WRKRCOMP,
                    STMACMTH = (short)empObj.STMACMTH,
                    USERDEF1 = empObj.USRDEFND1,
                    USERDEF2 = empObj.USERDEF2,
                    MARITALSTATUS = (short)empObj.MARITALSTATUS,
                    BENADJDATE = empObj.BENADJDATE,
                    LASTDAYWORKED_I = empObj.LASTDAYWORKED_I,
                    BIRTHDAY = (short)empObj.BIRTHDAY,
                    BIRTHMONTH = (short)empObj.BIRTHMONTH,
                    SPOUSE = empObj.SPOUSE,
                    SPOUSESSN = empObj.SPOUSESSN,
                    NICKNAME = empObj.NICKNAME,
                    ALTERNATENAME = empObj.ALTERNATENAME,
                    STATUSCD = empObj.STATUSCD,
                    HRSTATUS = (short)empObj.HRSTATUS,
                    DATEOFLASTREVIEW_I = empObj.DATEOFLASTREVIEW_I,
                    DATEOFNEXTREVIEW_I = empObj.DATEOFNEXTREVIEW_I,
                    BENEFITEXPIRE_I = empObj.BENEFITEXPIRE_I,
                    HANDICAPPED = (short)empObj.HANDICAPPED,
                    VETERAN = (short)empObj.VETERAN,
                    VIETNAMVETERAN = (short)empObj.VIETNAMVETERAN,
                    DISABLEDVETERAN = (short)empObj.DISABLEDVETERAN,
                    UNIONEMPLOYEE = (short)empObj.UNIONEMPLOYEE,
                    SMOKER_I = (short)empObj.SMOKER_I,
                    CITIZEN = (short)empObj.CITIZEN,
                    VERIFIED = (short)empObj.VERIFIED,
                    I9RENEW = empObj.I9RENEW,
                    Primary_Pay_Record = empObj.Primary_Pay_Record,
                    CHANGEBY_I = empObj.CHANGEBY_I,
                    CHANGEDATE_I = empObj.CHANGEDATE_I,
                    UNIONCD = empObj.UNIONCD,
                    RATECLSS = empObj.RATECLSS,
                    FEDCLSSCD = empObj.FEDCLSSCD,
                    OTHERVET = (short)empObj.OTHERVET,
                    Military_Discharge_Date = empObj.Military_Discharge_Date,
                    DefaultFromClass = (short)empObj.DefaultFromClass,
                    UpdateIfExists = (short)(empObj.UpdateIfExists = 1),
                    RequesterTrx = (short)(empObj.RequesterTrx = 1),
                    USRDEFND1 = empObj.USERDEF1,
                    USRDEFND2 = empObj.USRDEFND2,
                    USRDEFND3 = empObj.USRDEFND3,
                    USRDEFND4 = empObj.USRDEFND4,
                    USRDEFND5 = empObj.USRDEFND5,
                    SOCSCNUM = empObj.SOCSCNUM,
                    DEPRTMNT = empObj.DEPRTMNT ?? "SALE",
                    JOBTITLE = empObj.JOBTITLE ?? "TEC",

                };


                // Populate the RMCustomerMasterType schema with the taUpdateCreateCustomerRcd XML node
                employee.taCreateEmployee = newCust;
                UPRCreateEmployeeType[] myEmployeeMAster = { employee };

                // Populate the eConnectType object with the RMCustomerMasterType schema object
                eConnect.UPRCreateEmployeeType = myEmployeeMAster;

                // Create objects to create file and write the customer XML to the file
                FileStream fs = new FileStream(filename, FileMode.Create);
                XmlTextWriter writer = new XmlTextWriter(fs, new UTF8Encoding());

                // Serialize the eConnectType object to a file using the XmlTextWriter.
                serializer.Serialize(writer, eConnect);
                writer.Close();

            }
            catch (Exception ex)
            {

            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMPLOYID,FRSTNAME,LASTNAME,ADDRESS1,ADRSCODE,CITY,ZIPCODE,EMPLCLAS,INACTIVE,MIDLNAME,EMPLSUFF,ADDRESS2,ADDRESS3,STATE,COUNTY,COUNTRY,PHONE1,PHONE2,PHONE3,FAX,BRTHDATE,GENDER,ETHNORGN,DIVISIONCODE_I,SUPERVISORCODE_I,LOCATNID,WCACFPAY,AccountNumber,WKHRPRYR,STRTDATE,DEMPINAC,RSNEMPIN,SUTASTAT,WRKRCOMP,STMACMTH,USERDEF1,USERDEF2,MARITALSTATUS,BENADJDATE,LASTDAYWORKED_I,BIRTHDAY,BIRTHMONTH,SPOUSE,SPOUSESSN,NICKNAME,ALTERNATENAME,STATUSCD,HRSTATUS,DATEOFLASTREVIEW_I,DATEOFNEXTREVIEW_I,BENEFITEXPIRE_I,HANDICAPPED,VETERAN,VIETNAMVETERAN,DISABLEDVETERAN,UNIONEMPLOYEE,SMOKER_I,CITIZEN,VERIFIED,I9RENEW,Primary_Pay_Record,CHANGEBY_I,CHANGEDATE_I,UNIONCD,RATECLSS,FEDCLSSCD,OTHERVET,Military_Discharge_Date,DefaultFromClass,UpdateIfExists,RequesterTrx,USRDEFND1,USRDEFND2,USRDEFND3,USRDEFND4,USRDEFND5,SOCSCNUM,DEPRTMNT,JOBTITLE")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
