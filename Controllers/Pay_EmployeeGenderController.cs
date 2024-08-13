using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eConnectWebApp.Data;
using eConnectWebApp.Models.ViewModels;

namespace eConnectWebApp.Controllers
{
    public class Pay_EmployeeGenderController : Controller
    {
        private eConnectWebAppContext db = new eConnectWebAppContext();

        // GET: Pay_EmployeeGender
        public ActionResult Index()
        {
            return View(db.Pay_EmployeeGender.ToList());
        }

        // GET: Pay_EmployeeGender/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pay_EmployeeGender pay_EmployeeGender = db.Pay_EmployeeGender.Find(id);
            if (pay_EmployeeGender == null)
            {
                return HttpNotFound();
            }
            return View(pay_EmployeeGender);
        }

        // GET: Pay_EmployeeGender/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pay_EmployeeGender/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeGenderID,EmployeeGender")] Pay_EmployeeGender pay_EmployeeGender)
        {
            if (ModelState.IsValid)
            {
                db.Pay_EmployeeGender.Add(pay_EmployeeGender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pay_EmployeeGender);
        }

        // GET: Pay_EmployeeGender/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pay_EmployeeGender pay_EmployeeGender = db.Pay_EmployeeGender.Find(id);
            if (pay_EmployeeGender == null)
            {
                return HttpNotFound();
            }
            return View(pay_EmployeeGender);
        }

        // POST: Pay_EmployeeGender/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeGenderID,EmployeeGender")] Pay_EmployeeGender pay_EmployeeGender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pay_EmployeeGender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pay_EmployeeGender);
        }

        // GET: Pay_EmployeeGender/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pay_EmployeeGender pay_EmployeeGender = db.Pay_EmployeeGender.Find(id);
            if (pay_EmployeeGender == null)
            {
                return HttpNotFound();
            }
            return View(pay_EmployeeGender);
        }

        // POST: Pay_EmployeeGender/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pay_EmployeeGender pay_EmployeeGender = db.Pay_EmployeeGender.Find(id);
            db.Pay_EmployeeGender.Remove(pay_EmployeeGender);
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
