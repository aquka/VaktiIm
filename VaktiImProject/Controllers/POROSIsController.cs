using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VaktiImProject.BLL;
using VaktiImProject.Models;

namespace VaktiImProject.Controllers
{
    public class POROSIsController : Controller
    {
        private Vakti_Im_Entities db = new Vakti_Im_Entities();

        // GET: POROSIs
        public ActionResult Index()
        {
            var pOROSIs = db.POROSIs.Include(p => p.ADRESA).Include(p => p.AspNetUser).Include(p => p.AspNetUser1);
            return View(pOROSIs.ToList());
        }
        public ActionResult Porosi()
        {
            return View(db.Procedure1());
        }
        public ActionResult DetajePorosie(int id)
        {
            var ordersService = new OrdersService();
            var model = ordersService.MerrListenEPorosive(id);


            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult ShfaqPorosi1()
        {
            return View(db.ShfaqPorosi1());
        }

        public ActionResult ShfaqPorosi0()
        {
            return View(db.ShfaqPorosit0());
        }
        // GET: POROSIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POROSI pOROSI = db.POROSIs.Find(id);
            if (pOROSI == null)
            {
                return HttpNotFound();
            }
            return View(pOROSI);
        }

        // GET: POROSIs/Create
        public ActionResult Create()
        {
            ViewBag.adresa_id = new SelectList(db.ADRESAs, "adrese_id", "rruga");
            ViewBag.klient_id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.pergjegjes_id = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: POROSIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "porosi_id,adresa_id,datetime_Porosi,status_porosie,klient_id,pergjegjes_id,data_Modifikimit")] POROSI pOROSI)
        {
            if (ModelState.IsValid)
            {
                db.POROSIs.Add(pOROSI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.adresa_id = new SelectList(db.ADRESAs, "adrese_id", "rruga", pOROSI.adresa_id);
            ViewBag.klient_id = new SelectList(db.AspNetUsers, "Id", "Email", pOROSI.klient_id);
            ViewBag.pergjegjes_id = new SelectList(db.AspNetUsers, "Id", "Email", pOROSI.pergjegjes_id);
            return View(pOROSI);
        }

        // GET: POROSIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POROSI pOROSI = db.POROSIs.Find(id);
            if (pOROSI == null)
            {
                return HttpNotFound();
            }
            ViewBag.adresa_id = new SelectList(db.ADRESAs, "adrese_id", "rruga", pOROSI.adresa_id);
            ViewBag.klient_id = new SelectList(db.AspNetUsers, "Id", "Email", pOROSI.klient_id);
            ViewBag.pergjegjes_id = new SelectList(db.AspNetUsers, "Id", "Email", pOROSI.pergjegjes_id);
            return View(pOROSI);
        }

        // POST: POROSIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "porosi_id,adresa_id,datetime_Porosi,status_porosie,klient_id,pergjegjes_id,data_Modifikimit")] POROSI pOROSI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOROSI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.adresa_id = new SelectList(db.ADRESAs, "adrese_id", "rruga", pOROSI.adresa_id);
            ViewBag.klient_id = new SelectList(db.AspNetUsers, "Id", "Email", pOROSI.klient_id);
            ViewBag.pergjegjes_id = new SelectList(db.AspNetUsers, "Id", "Email", pOROSI.pergjegjes_id);
            return View(pOROSI);
        }

        // GET: POROSIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POROSI pOROSI = db.POROSIs.Find(id);
            if (pOROSI == null)
            {
                return HttpNotFound();
            }
            return View(pOROSI);
        }

        // POST: POROSIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POROSI pOROSI = db.POROSIs.Find(id);
            db.POROSIs.Remove(pOROSI);
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
