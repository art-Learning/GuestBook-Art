using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cowell_GuestBook.Models;

namespace Cowell_GuestBook.Controllers
{
    public class ForumController : Controller
    {
        private MVCTESTEntities db = new MVCTESTEntities();

        // GET: Forum
        public ActionResult Index()
        {
            return View(db.Forum.ToList());
        }

        // GET: Forum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = db.Forum.Find(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection frm)
        {
            var obj = new Forum();
            obj.BUD_DTM = DateTime.Now;
            if (TryUpdateModel<Forum>(obj, "", frm.AllKeys, new string[] { })) {
                db.Forum.Add(obj);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(obj);
        }

        // GET: Forum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = db.Forum.Find(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,FormCollection frm)
        {
            var obj = db.Forum.Find(id);
            if (TryUpdateModel<Forum>(obj, "", frm.AllKeys, new string[] { "BUD_DTM" })) {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: Forum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = db.Forum.Find(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }

        // POST: Forum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Forum forum = db.Forum.Find(id);
            db.Forum.Remove(forum);
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
