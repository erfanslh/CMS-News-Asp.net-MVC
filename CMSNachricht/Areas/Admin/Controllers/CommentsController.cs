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
    public class CommentsController : Controller
    {
        private DbNachrichtContext db = new DbNachrichtContext();
        CommentService _commentService;
        public CommentsController()
        {
            _commentService = new CommentService(db);
        }
        // GET: Admin/Comments
        public ActionResult Index()
        {
            var cm = _commentService.GetAll();
            var Allcomments = AutoMapperConfig.mapper.Map<IEnumerable<Comment>, List<CommentViewModel>>(cm);
            return View(Allcomments);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment commentEntity = _commentService.GetEntity(id.Value);
            if (commentEntity == null)
            {
                return HttpNotFound();
            }
            var findcomment = AutoMapperConfig.mapper.Map<Comment, CommentViewModel>(commentEntity);
            return View(findcomment);
        }

        // GET: Admin/Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentService.GetEntity(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            var CommentMap = AutoMapperConfig.mapper.Map<Comment, CommentViewModel>(comment);
            return View(CommentMap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,Description,Name,Email,RegisterDate,IsActive,NewsId,BaseDescription")] CommentViewModel commentViewModel)
        {
            if (ModelState.IsValid)
            {
                var commentMap = AutoMapperConfig.mapper.Map<CommentViewModel, Comment>(commentViewModel);
                _commentService.Update(commentMap);
                _commentService.Save();
                return RedirectToAction("Index");
            }
            return View(commentViewModel);
        }

        // GET: Admin/Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentService.GetEntity(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            var mapping = AutoMapperConfig.mapper.Map<Comment, CommentViewModel> (comment);
            return View(mapping);
        }

        // POST: Admin/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = _commentService.GetEntity(id);
            _commentService.Delete(comment);
            _commentService.Save();
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
