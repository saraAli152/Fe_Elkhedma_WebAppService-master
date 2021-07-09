using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewWeppAppServices2.Models;
using System.IO;
using Microsoft.AspNet.Identity;

namespace NewWeppAppServices2.Controllers
{
    [Authorize]
    public class ServesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Serves
        public ActionResult Index()
        {
            return View(db.Serves.ToList());
        }
       
        public ActionResult Index2(string id)
        {
            return View(db.Serves.Where(a=>a.UserID == id).ToList());
        }
        // GET: Serves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serve serve = db.Serves.Find(id);
            if (serve == null)
            {
                return HttpNotFound();
            }
            return View(serve);
        }

        // GET: Serves/Create
        public ActionResult Create()
        {
            ViewBag.servetype = new SelectList(db.Categories.ToList(), "Id", "CategoryName", 1);
            //ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "CategoryName", 1);
            return View();
        }

        // POST: Serves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,ServeName,ServeContent,ServeImage,CategoryId")] Serve serve)
            public ActionResult Create( Serve serve, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                serve.ServeImage = upload.FileName;
                serve.UserID = User.Identity.GetUserId();
                db.Serves.Add(serve);
                db.SaveChanges();
                return RedirectToAction("Index2",new{ id= serve.UserID });
            }
            ViewBag.servetype = new SelectList(db.Categories.ToList(), "Id", "CategoryName", serve.CategoryId);

            return View(serve);
        }

        // GET: Serves/Edit/5
        public ActionResult Edit(int? id)
        {
           
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serve serve = db.Serves.Find(id);
            if (serve == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "CategoryName", serve.CategoryId);
            return View(serve);
        }

        // POST: Serves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Serve serve, HttpPostedFileBase upload)
        {
            
            if (ModelState.IsValid)
            {

             
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                serve.ServeImage= upload.FileName;   
                db.Entry(serve).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Index2", new { id = serve.UserID });
            }
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "CategoryName", serve.CategoryId);
            return View(serve);
        }

        // GET: Serves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serve serve = db.Serves.Find(id);
            if (serve == null)
            {
                return HttpNotFound();
            }
            return View(serve);
        }

        // POST: Serves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Serve serve = db.Serves.Find(id);
            db.Serves.Remove(serve);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return RedirectToAction("Index2", new { id = serve.UserID });

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
