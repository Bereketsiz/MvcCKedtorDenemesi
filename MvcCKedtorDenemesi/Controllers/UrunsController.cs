using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcCKedtorDenemesi.Models;
using System.IO;

namespace MvcCKedtorDenemesi.Controllers
{
    public class UrunsController : Controller
    {
        private UrunContex db = new UrunContex();

        // GET: Uruns
        public ActionResult Index()
        {
            return View(db.Uruns.ToList());
        }

        // GET: Uruns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Uruns.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // GET: Uruns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uruns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,UrunAdi,Fiyat,UrunResim,Detay")] Urun urun, HttpPostedFileBase UrunResim)
        {
            if (ModelState.IsValid)
            {
                if (UrunResim != null)
                {
                    FileInfo DosyaBilgisi = new FileInfo(UrunResim.FileName);
                    string yeniIsim = Guid.NewGuid().ToString("N") + DosyaBilgisi.Extension;
                    UrunResim.SaveAs(Server.MapPath("~/Content/Upload/UrunResim/"+yeniIsim));
                    urun.UrunResim = yeniIsim;
                    db.Uruns.Add(urun);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Uyarı","Lütfen Ürün için bir resim seçiniz.");
                    return View(urun);
                }


            }

            return View(urun);
        }

        // GET: Uruns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Uruns.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // POST: Uruns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,UrunAdi,Fiyat,UrunResim,Detay")] Urun urun, HttpPostedFileBase UrunResim)
        {
            if (ModelState.IsValid)
            {
                if (UrunResim != null)
                {
                    FileInfo DosyaBilgisi = new FileInfo(UrunResim.FileName);
                    string yeniIsim = Guid.NewGuid().ToString("N") + DosyaBilgisi.Extension;
                    UrunResim.SaveAs(Server.MapPath("~/Content/Upload/UrunResim/" + yeniIsim));
                    urun.UrunResim = yeniIsim;
                    db.Uruns.Add(urun);
                    db.Entry(urun).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    
                    db.Uruns.Add(urun);
                    db.Entry(urun).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Edit");
                }
                
            }
            return View(urun);
        }

        // GET: Uruns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Uruns.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // POST: Uruns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urun urun = db.Uruns.Find(id);
            db.Uruns.Remove(urun);
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
