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
    public class ArticleController : Controller
    {
        private MVCTESTEntities db = new MVCTESTEntities();

        public ActionResult Index(int? ForumID)
        {
            IQueryable<ARTICLE> objs;
            if (ForumID == null) {
                // Get: /Article
                objs=db.ARTICLE.Include(a => a.Forum);
            } else {
                // Get: /Article?forumID=12
                objs=db.ARTICLE.Where(x=>x.FORUM_ID==ForumID).OrderBy(x=>x.BUD_DTM);
                ViewData["ForumDetailModel"] = db.Forum.Find(ForumID);
            }
            return View(objs.ToList());
        }

        // GET: Article/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICLE aRTICLE = db.ARTICLE.Find(id);
            if (aRTICLE == null)
            {
                return HttpNotFound();
            }
            return View(aRTICLE);
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            ViewBag.FORUM_ID = new SelectList(db.Forum, "ID", "TITLE");
            return View();
        }

        // POST: Article/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FORUM_ID,TITLE,BODY,BUD_DTM,UPD_DTM,AUTHOR")] ARTICLE aRTICLE)
        {
            if (ModelState.IsValid)
            {
                db.ARTICLE.Add(aRTICLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FORUM_ID = new SelectList(db.Forum, "ID", "TITLE", aRTICLE.FORUM_ID);
            return View(aRTICLE);
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICLE aRTICLE = db.ARTICLE.Find(id);
            if (aRTICLE == null)
            {
                return HttpNotFound();
            }
            ViewBag.FORUM_ID = new SelectList(db.Forum, "ID", "TITLE", aRTICLE.FORUM_ID);
            return View(aRTICLE);
        }

        // POST: Article/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FORUM_ID,TITLE,BODY,BUD_DTM,UPD_DTM,AUTHOR")] ARTICLE aRTICLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRTICLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FORUM_ID = new SelectList(db.Forum, "ID", "TITLE", aRTICLE.FORUM_ID);
            return View(aRTICLE);
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICLE aRTICLE = db.ARTICLE.Find(id);
            if (aRTICLE == null)
            {
                return HttpNotFound();
            }
            return View(aRTICLE);
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ARTICLE aRTICLE = db.ARTICLE.Find(id);
            db.ARTICLE.Remove(aRTICLE);
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
