using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cowell_GuestBook.Models;

namespace Cowell_GuestBook.Controllers {
    public class replyController : Controller {
        private MVCTESTEntities db = new MVCTESTEntities();

        // GET: reply
        public ActionResult Index(int? ArticleID) {
            IQueryable<ARTICLEREPLY> objs;
            if (ArticleID == null) {
                objs = db.ARTICLEREPLY.Include(a => a.ARTICLE);
            } else {
                objs = db.ARTICLEREPLY.Where(x => x.ARTICLE_ID == ArticleID).OrderBy(x => x.BUD_DTM);
                ViewData["ArticleID"] = ArticleID;
            }
            return View(objs.ToList());
        }

        // GET: reply/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICLEREPLY aRTICLEREPLY = db.ARTICLEREPLY.Find(id);
            if (aRTICLEREPLY == null) {
                return HttpNotFound();
            }
            return View(aRTICLEREPLY);
        }

        // GET: reply/Create
        public ActionResult Create(int? articleID) {
            if (articleID == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewData["articleID"] = articleID;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection frm) {
            ARTICLEREPLY obj = new ARTICLEREPLY();
            obj.BUD_DTM = DateTime.Now;
            if (TryUpdateModel<ARTICLEREPLY>(obj, "", frm.AllKeys, new string[] {"" })) {
                db.ARTICLEREPLY.Add(obj);
                db.SaveChanges();
                return RedirectToAction("details", "article", new { ID = obj.ARTICLE_ID });
            }
            return View(obj);
        }

        // GET: reply/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICLEREPLY aRTICLEREPLY = db.ARTICLEREPLY.Find(id);
            if (aRTICLEREPLY == null) {
                return HttpNotFound();
            }
            
            return View(aRTICLEREPLY);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,FormCollection frm) {
            var obj = db.ARTICLEREPLY.Find(id);
            if (TryUpdateModel<ARTICLEREPLY>(obj, "", frm.AllKeys, new string[] { })) {
                db.SaveChanges();
                return RedirectToAction("details", "article", new { ID = obj.ARTICLE_ID });
            }
                return View(obj);
        }

        // GET: reply/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICLEREPLY aRTICLEREPLY = db.ARTICLEREPLY.Find(id);
            if (aRTICLEREPLY == null) {
                return HttpNotFound();
            }
            return View(aRTICLEREPLY);
        }

        // POST: reply/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            ARTICLEREPLY aRTICLEREPLY = db.ARTICLEREPLY.Find(id);
            db.ARTICLEREPLY.Remove(aRTICLEREPLY);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
