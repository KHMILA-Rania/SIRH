using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemandeMission.Models;
using System.Data.Entity.Validation;

namespace DemandeMission.Controllers
{
    public class MISSIONController : Controller
    {
        private Mission_Entities db = new Mission_Entities();

        // GET: MISSION
        public ActionResult Liste_Mission()
        {
            return View(db.MISSION.ToList());
        }

        // GET: MISSION/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MISSION mISSION = db.MISSION.Find(id);
            if (mISSION == null)
            {
                return HttpNotFound();
            }
            return View(mISSION);
        }

        // GET: MISSION/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MISSION/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOM,PRÉNOM,N__PASSEPORT,NATIONALITÉ,FONCTION,TITRE_EQUIPE,MOTIF_DE_MISSION,INTITULÉ_DE_MISSION,DATE__DÉPART,DATE_RETOUR,OBJET_DE_MISSION,TELEPHONE,EMAIL,STATUS")] MISSION mISSION)
        {
            if (ModelState.IsValid)
            {
                db.MISSION.Add(mISSION);
                db.SaveChanges();
                return RedirectToAction("Liste_Mission");
            }

            return View(mISSION);
        }

        // GET: MISSION/Treat/5
        public ActionResult Treat(decimal id)
        {
            if (id <0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MISSION mISSION = db.MISSION.Find(id);
            if (mISSION == null)
            {
                return HttpNotFound();
            }
            return View(mISSION);
        }

        // POST: MISSION/Treat/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Treat([Bind(Include = "ID,NOM,PRÉNOM,N__PASSEPORT,NATIONALITÉ,FONCTION,TITRE_EQUIPE,MOTIF_DE_MISSION,INTITULÉ_DE_MISSION,DATE__DÉPART,DATE_RETOUR,OBJET_DE_MISSION,TELEPHONE,EMAIL,STATUS")] MISSION mISSION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mISSION).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    //throw;
                }
                System.Threading.Thread.Sleep(200);
                return RedirectToAction("Liste_Mission");
            }
            return View(mISSION);
        }

        // GET: MISSION/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MISSION mISSION = db.MISSION.Find(id);
            if (mISSION == null)
            {
                return HttpNotFound();
            }
            return View(mISSION);
        }

        // POST: MISSION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            MISSION mISSION = db.MISSION.Find(id);
            db.MISSION.Remove(mISSION);
            db.SaveChanges();
            return RedirectToAction("Liste_Mission");
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
