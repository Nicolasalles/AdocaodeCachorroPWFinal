using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdocaodeCachorro.DAL;
using AdocaodeCachorro.Models;

namespace AdocaodeCachorro.Controllers
{
    public class CachorroController : Controller
    {
        private VetContext db = new VetContext();

        // GET: Cachorro
        public ActionResult Index()
        {
            var cachorros = db.Cachorros.Include(c => c.Dono);
            return View(cachorros.ToList());
        }

        // GET: Cachorro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cachorro cachorro = db.Cachorros.Find(id);
            if (cachorro == null)
            {
                return HttpNotFound();
            }
            return View(cachorro);
        }

        // GET: Cachorro/Create
        public ActionResult Create()
        {
            ViewBag.DonoID = new SelectList(db.Donos, "DonoID", "NomeDono");
            return View();
        }

        // POST: Cachorro/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CachorroID,CachorroNome,DonoID,Raca,Idade")] Cachorro cachorro)
        {
            if (ModelState.IsValid)
            {
                db.Cachorros.Add(cachorro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonoID = new SelectList(db.Donos, "DonoID", "NomeDono", cachorro.DonoID);
            return View(cachorro);
        }

        // GET: Cachorro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cachorro cachorro = db.Cachorros.Find(id);
            if (cachorro == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonoID = new SelectList(db.Donos, "DonoID", "NomeDono", cachorro.DonoID);
            return View(cachorro);
        }

        // POST: Cachorro/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CachorroID,CachorroNome,DonoID,Raca,Idade")] Cachorro cachorro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cachorro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonoID = new SelectList(db.Donos, "DonoID", "NomeDono", cachorro.DonoID);
            return View(cachorro);
        }

        // GET: Cachorro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cachorro cachorro = db.Cachorros.Find(id);
            if (cachorro == null)
            {
                return HttpNotFound();
            }
            return View(cachorro);
        }

        // POST: Cachorro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cachorro cachorro = db.Cachorros.Find(id);
            db.Cachorros.Remove(cachorro);
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
