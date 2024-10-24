using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMSNachricht.Models.ViewModel;
using CMSNachrichtModel.Context;
using CMSNachrichtModel.Model;
using CMSNachrichtService.Service;
using WebApplication3.App_Start;

namespace CMSNachricht.Areas.Admin.Controllers
{
    public class AuthorsController : Controller
    {
        private DbNachrichtContext db = new DbNachrichtContext();
        AuthorService _authorService;
        public AuthorsController()
        {
            _authorService = new AuthorService(db);
        }
        // GET: Admin/Authors
        public ActionResult Index()
        {
            var all =_authorService.GetAll();
            var Map = AutoMapperConfig.mapper.Map<IEnumerable<Author>, List<AuthorViewModel>>(all);
            return View(Map);
        }

        // GET: Admin/Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = _authorService.GetEntity(id.Value);
            if (author == null)
            {
                return HttpNotFound();
            }
            var map = AutoMapperConfig.mapper.Map<Author, AuthorViewModel>(author);
            return View(map);
        }

        // GET: Admin/Authors/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthorId,Mobilenumber,Password,BaseDescription")] AuthorViewModel authorvm)
        {
            if (ModelState.IsValid)
            {
                authorvm.IsActive = true;
                authorvm.RegisterDate = DateTime.Now;
                var map = AutoMapperConfig.mapper.Map<AuthorViewModel, Author>(authorvm);
                _authorService.Add(map);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorvm);
        }

        // GET: Admin/Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = _authorService.GetEntity(id.Value);
            if (author == null)
            {
                return HttpNotFound();
            }
            var map = AutoMapperConfig.mapper.Map<Author, AuthorViewModel>(author);
            return View(map);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthorId,Mobilenumber,Password,RegisterDate,IsActive,BaseDescription")] AuthorViewModel authorvm)
        {
            if (ModelState.IsValid)
            {
                var mapping = AutoMapperConfig.mapper.Map<AuthorViewModel, Author>(authorvm);
                _authorService.Update(mapping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorvm);
        }

        // GET: Admin/Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = _authorService.GetEntity(id.Value);
            if (author == null)
            {
                return HttpNotFound();
            }
            var map = AutoMapperConfig.mapper.Map<Author, AuthorViewModel>(author);
            return View(map);
        }

        // POST: Admin/Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = _authorService.GetEntity(id);
            _authorService.Delete(author);
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
