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
    public class replyController : Controller
    {
        private MVCTESTEntities db = new MVCTESTEntities();

        // GET: reply
        public ActionResult Index()
        {
            var aRTICLEREPLY = db.ARTICLEREPLY.Include(a => a.ARTICLE);
            return View(aRTICLEREPLY.ToList());
        }

        // GET: reply/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICLEREPLY aRTICLEREPLY = db.ARTICLEREPLY.Find(id);
            if (aRTICLEREPLY == null)
            {
                return HttpNotFound();
            }
            return View(aRTICLEREPLY);
        }

        // GET: reply/Create
        public ActionResult Create()
        {
            ViewBag.ARTICLE_ID = new SelectList(db.ARTICLE, "ID", "TITLE");
            return View();
        }

        // POST: reply/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ARTICLE_ID,BODY,BUD_DTM,AUTHOR")] ARTICLEREPLY aRTICLEREPLY)
        {
            if (ModelState.IsValid)
            {
                db.ARTICLEREPLY.Add(aRTICLEREPLY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ARTICLE_ID = new SelectList(db.ARTICLE, "ID", "TITLE", aRTICLEREPLY.ARTICLE_ID);
            return View(aRTICLEREPLY);
        }

        // GET: reply/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICLEREPLY aRTICLEREPLY = db.ARTICLEREPLY.Find(id);
            if (aRTICLEREPLY == null)
            {
                return HttpNotFound();
            }
            ViewBag.ARTICLE_ID = new SelectList(db.ARTICLE, "ID", "TITLE", aRTICLEREPLY.ARTICLE_ID);
            return View(aRTICLEREPLY);
        }

        // POST: reply/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ARTICLE_ID,BODY,BUD_DTM,AUTHOR")] ARTICLEREPLY aRTICLEREPLY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRTICLEREPLY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ARTICLE_ID = new SelectList(db.ARTICLE, "ID", "TITLE", aRTICLEREPLY.ARTICLE_ID);
            return View(aRTICLEREPLY);
        }

        // GET: reply/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICLEREPLY aRTICLEREPLY = db.ARTICLEREPLY.Find(id);
            if (aRTICLEREPLY == null)
            {
                return HttpNotFound();
            }
            return View(aRTICLEREPLY);
        }

        // POST: reply/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ARTICLEREPLY aRTICLEREPLY = db.ARTICLEREPLY.Find(id);
            db.ARTICLEREPLY.Remove(aRTICLEREPLY);
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
