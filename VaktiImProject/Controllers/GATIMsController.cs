using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VaktiImProject.BLL;
using VaktiImProject.Models;

namespace VaktiImProject.Controllers
{
    public class GATIMsController : Controller
    {
        private Vakti_Im_Entities db = new Vakti_Im_Entities();

        //        // GET: GATIMs
        //        public ActionResult Index()
        //        {
        //            var gATIMs = db.GATIMs.Include(g => g.PERDORUE).Include(g => g.PERDORUE1).Include(g => g.KATEGORI);
        //            return View(gATIMs.ToList());
        //        }
        //        public ActionResult GatimetAktive()
        //        {
        //            var gatime = new GatimetService();
        //            var model = gatime.MerrListenEGatimeve();

        //            return View(model);
        //        }

        //        // GET: GATIMs/Details/5
        //        public ActionResult Details(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            GATIM gATIM = db.GATIMs.Where(x => x.gatim_id == id).FirstOrDefault();
        //            gATIM = db.GATIMs.Find(id);
        //            GATIM gt = new GATIM { foto = "data:Foto" };

        //            gt.gatim = gATIM;

        //            //GATIM gATIM = db.GATIMs.Find(id);
        //            if (gATIM == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return View(gATIM);
        //        }

        //        public ActionResult GatimeDetails(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            GATIM gATIM = db.GATIMs.Find(id);
        //            if (gATIM == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return View(gATIM);
        //        }

        //        [HttpGet]
        //        public ActionResult Add()
        //        {
        //            return View();
        //        }
        //        [HttpPost]
        //        public ActionResult Add(GATIM gATIM)
        //        {
        //            string filename = Path.GetFileNameWithoutExtension(gATIM.ImageFile.FileName);
        //            string extension = Path.GetExtension(gATIM.ImageFile.FileName);
        //            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
        //            gATIM.foto = "~/Foto/" + filename;
        //            filename = Path.Combine(Server.MapPath("~/Foto/") + filename);
        //            //gATIM.ImageFile.SaveAs(Server.MapPath("~/Foto" + filename));
        //            db.GATIMs.Add(gATIM);
        //            db.SaveChanges();

        //            ModelState.Clear();
        //            return View();

        //        }

        //        [HttpGet]
        //        public ActionResult View(int id)
        //        {
        //            GATIM gATIM = new GATIM();

        //            gATIM = db.GATIMs.Where(x => x.gatim_id == id).FirstOrDefault();


        //            return View(gATIM);
        //        }


        //        // GET: GATIMs/Create


        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Edit([Bind(Include = "gatim_id,emriGatimit,pershkrimi,cmimi,disponueshmeria,foto,datakrijimit,datamodifikimit,createdBy,modifiedBy,kategori_id")] GATIM gATIM)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.Entry(gATIM).State = EntityState.Modified;
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //            ViewBag.createdBy = new SelectList(db.PERDORUES, "perdorues_id", "emri", gATIM.createdBy);
        //            ViewBag.modifiedBy = new SelectList(db.PERDORUES, "perdorues_id", "emri", gATIM.modifiedBy);
        //            ViewBag.kategori_id = new SelectList(db.KATEGORIs, "kategori_id", "emri", gATIM.kategori_id);
        //            return View(gATIM);
        //        }

        //        // POST: GATIMs/Edit/5
        //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //        //[HttpPost]
        //        //[ValidateAntiForgeryToken]
        //        //public ActionResult Edit([Bind(Include = "gatim_id,emriGatimit,pershkrimi,cmimi,disponueshmeria,foto,datamodifikimit,modifiedBy,kategori_id")] GATIM gATIM)
        //        //{
        //        //    if (ModelState.IsValid)
        //        //    {
        //        //        var gatimet = db.GATIMs.FirstOrDefault(s => s.gatim_id == gATIM.gatim_id);
        //        //        if (gatimet != null)
        //        //        {

        //        //            gatimet.emriGatimit = gATIM.emriGatimit;
        //        //            gatimet.pershkrimi = gATIM.pershkrimi;
        //        //            gatimet.cmimi = gATIM.cmimi;
        //        //            gatimet.disponueshmeria = gATIM.disponueshmeria;
        //        //            gatimet.foto = gATIM.foto;
        //        //            gatimet.datamodifikimit = DateTime.Now;
        //        //            gatimet.modifiedBy = gATIM.modifiedBy;
        //        //            gatimet.kategori_id = gATIM.kategori_id;

        //        //            db.Entry(gatimet).State = EntityState.Modified;
        //        //            db.SaveChanges();
        //        //            return RedirectToAction("Index");

        //        //        }


        //        //    }
        //        //    ViewBag.createdBy = new SelectList(db.PERDORUES, "perdorues_id", "emri", gATIM.createdBy);
        //        //    ViewBag.modifiedBy = new SelectList(db.PERDORUES, "perdorues_id", "emri", gATIM.modifiedBy);
        //        //    ViewBag.kategori_id = new SelectList(db.KATEGORIs, "kategori_id", "emri", gATIM.kategori_id);
        //        //    return View(gATIM);
        //        //}

        //        // GET: GATIMs/Delete/5
        //        public ActionResult Delete(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            GATIM gATIM = db.GATIMs.Find(id);
        //            if (gATIM == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return View(gATIM);
        //        }

        //        // POST: GATIMs/Delete/5
        //        [HttpPost, ActionName("Delete")]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult DeleteConfirmed(int id)
        //        {
        //            GATIM gATIM = db.GATIMs.Find(id);
        //            db.GATIMs.Remove(gATIM);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        protected override void Dispose(bool disposing)
        //        {
        //            if (disposing)
        //            {
        //                db.Dispose();
        //            }
        //            base.Dispose(disposing);
        //        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(GATIM gATIM)
        {
            string filename = "";// Path.GetFileNameWithoutExtension(gATIM.ImageFile.FileName);
            string extension = "";// Path.GetExtension(gATIM.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            gATIM.foto = "~/Foto/" + filename;
            filename = Path.Combine(Server.MapPath("~/Foto/") + filename);
            //gATIM.ImageFile.SaveAs(Server.MapPath("~/Foto" + filename));
            db.GATIMs.Add(gATIM);
            db.SaveChanges();

            ModelState.Clear();
            return View();

        }
        [HttpGet]
        public ActionResult View(int id)
        {
            GATIM gATIM = new GATIM();

            gATIM = db.GATIMs.Where(x => x.gatim_id == id).FirstOrDefault();


            return View(gATIM);
        }

        public ActionResult Index()
        {
            try
            {
                var gATIMs = db.GATIMs.Include(g => g.AspNetUser).Include(g => g.AspNetUser1).Include(g => g.KATEGORI);
                return View(gATIMs.ToList());
            }
            catch (Exception ex)
            {
                return View();
            }


        }
        // GET: GATIMs/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GATIM gATIM = db.GATIMs.Where(x => x.gatim_id == id).FirstOrDefault();
            gATIM = db.GATIMs.Find(id);
            GATIM gt = new GATIM { foto = "data:Foto" };

            gt = gATIM;

            if (gATIM == null)
            {
                return HttpNotFound();
            }
            return View(gATIM);
        }
        // GET: GATIMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GATIM gATIM = db.GATIMs.Find(id);
            if (gATIM == null)
            {
                return HttpNotFound();
            }
            ViewBag.createdBy = new SelectList(db.AspNetUsers, "Id", "Email", gATIM.createdBy);
            ViewBag.modifiedBy = new SelectList(db.AspNetUsers, "Id", "emri", gATIM.modifiedBy);
            ViewBag.kategori_id = new SelectList(db.KATEGORIs, "kategori_id", "emri", gATIM.kategori_id);
            return View(gATIM);
        }

        // POST: GATIMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "gatim_id,emriGatimit,pershkrimi,cmimi,disponueshmeria,foto,datakrijimit,datamodifikimit,createdBy,modifiedBy,kategori_id")] GATIM gATIM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gATIM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.createdBy = new SelectList(db.AspNetUsers, "Id", "Email", gATIM.createdBy);
            ViewBag.modifiedBy = new SelectList(db.AspNetUsers, "Id", "Email", gATIM.modifiedBy);
            ViewBag.kategori_id = new SelectList(db.KATEGORIs, "kategori_id", "emri", gATIM.kategori_id);
            return View(gATIM);
        }

        // GET: GATIMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GATIM gATIM = db.GATIMs.Find(id);
            if (gATIM == null)
            {
                return HttpNotFound();
            }
            return View(gATIM);
        }

        // POST: GATIMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GATIM gATIM = db.GATIMs.Find(id);
            db.GATIMs.Remove(gATIM);
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

        public ActionResult GatimetAktive()
        {
            var gatime = new GatimetService();
            var model = gatime.MerrListenEGatimeve();

            return View(model);
        }

        public ActionResult GatimeDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GATIM gATIM = db.GATIMs.Find(id);
            if (gATIM == null)
            {
                return HttpNotFound();
            }
            return View(gATIM);
        }

    }
}
