using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VaktiImProject.Models;

namespace VaktiImProject.Controllers
{
    public class AspNetUsersController : Controller
    {
        private Vakti_Im_Entities db = new Vakti_Im_Entities();
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        // GET: PERDORUEs
        public ActionResult Index()
        {
            try
            {
                var pERDORUES = db.AspNetUsers.Include(p => p.AspNetRoles);
                return View(pERDORUES.ToList());
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }

        // GET: PERDORUEs/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspNetUser pERDORUE = db.AspNetUsers.Find(id);
                if (pERDORUE == null)
                {
                    return HttpNotFound();
                }
                return View(pERDORUE);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }
            // GET: PERDORUEs/Create
            public ActionResult Create()
        {
            try
            {
                ViewBag.rol_id = new SelectList(db.AspNetRoles, "Id", "Name");
                return View();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }

        // POST: PERDORUEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,PhoneNumber,UserName")] AspNetUser pERDORUE)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   // pERDORUE.krijimPerdorues = DateTime.Now;
                    db.AspNetUsers.Add(pERDORUE);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                //ViewBag.rol_id = new SelectList(db.AspNetRoles, "rol_id", "emri", pERDORUE.rol_id);
                return View(pERDORUE);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }

        // GET: PERDORUEs/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AspNetUser pERDORUE = db.AspNetUsers.Find(id);
                if (pERDORUE == null)
                {
                    return HttpNotFound();
                }
               // ViewBag.rol_id = new SelectList(db.AspNetRoles, "rol_id", "emri", pERDORUE.rol_id);
                return View(pERDORUE);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                ViewBag.ErrorMessage = "Ndodhi një problem gjatë përpunimit të të dhenave. Ju lutem kontaktoni me administratorin!";
                return View();
            }
        }

        // POST: PERDORUEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,PhoneNumber")] AspNetUser pERDORUE)
        {
            if (ModelState.IsValid)
            {
                var perdoruesEkzistues = db.AspNetUsers.FirstOrDefault(p => p.Id == pERDORUE.Id);
                if(perdoruesEkzistues != null)
                {
                    perdoruesEkzistues.Email = pERDORUE.Email;
                   // perdoruesEkzistues.mbiemri = pERDORUE.mbiemri;
                    perdoruesEkzistues.PhoneNumber = pERDORUE.PhoneNumber;
                    //perdoruesEkzistues.aktiv = pERDORUE.aktiv;
                   // perdoruesEkzistues.rol_id = pERDORUE.rol_id;
                   // perdoruesEkzistues.modifikimPerdoruesi = DateTime.Now;

                    db.Entry(perdoruesEkzistues).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Perdoruesi i kerkuar nuk ekziston!";
                   // ViewBag.rol_id = new SelectList(db.ROLIs, "rol_id", "emri", pERDORUE.rol_id);
                    return View(pERDORUE);
                }
                
            }
            //ViewBag.rol_id = new SelectList(db.ROLIs, "rol_id", "emri", pERDORUE.rol_id);
            return View(pERDORUE);
        }

        // GET: PERDORUEs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PERDORUE pERDORUE = db.PERDORUES.Find(id);
        //    if (pERDORUE == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pERDORUE);
        //}

        //// POST: PERDORUEs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    PERDORUE pERDORUE = db.PERDORUES.Find(id);
        //    db.PERDORUES.Remove(pERDORUE);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
