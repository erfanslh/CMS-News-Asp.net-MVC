using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
    public class NewsController : Controller
    {
        private DbNachrichtContext db = new DbNachrichtContext();
        private NewsService _newsService;
        private AuthorService _authorService;
        private NewsGroupService _newsGroupService;
        public NewsController()
        {
            _newsService = new NewsService(db);
            _authorService = new AuthorService(db);
            _newsGroupService = new NewsGroupService(db);
        }


        public ActionResult Index()
        {
            var newses = _newsService.GetAll().ToList();
            var Mapping = AutoMapperConfig.mapper.Map<IEnumerable<News> , List<NewsViewModel>>(newses);
            return View(Mapping);
        }

        // GET: Admin/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = _newsService.GetEntity(id.Value);
            if (news == null)
            {
                return HttpNotFound();
            }
            NewsViewModel finalNews = AutoMapperConfig.mapper.Map<News, NewsViewModel>(news);
            return View(finalNews);
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(_authorService.GetAll(), "AuthorId", "Mobilenumber");
            ViewBag.NewsGroupId = new SelectList(_newsGroupService.GetAll(), "NewsGroupId", "NewsGroupTitle");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "NewsTitle,NewsDescription,NewsGroupId")] 
                                      NewsViewModel newsViewModel, HttpPostedFileBase imgupload)
        {

            if (ModelState.IsValid)
            {

                string Imagename = "Null.png";
                #region IMAGE_Save_To_Server
                if (imgupload != null)
                {
                    if (imgupload.ContentType !="image/png" && imgupload.ContentType!="image/jpeg")
                    {
                        return View();
                    }
                     Imagename = Guid.NewGuid().ToString().Replace("-", " ") + Path.GetExtension(imgupload.FileName);
                     imgupload.SaveAs(Server.MapPath("/Images/News/" + Imagename));
                 
                }
                #endregion


                // User.Identity.Name == Name of User logged In(Here is mobileNumber)
                newsViewModel.AuthorId = _authorService.GetUserId(User.Identity.Name);
                newsViewModel.ImageName = Imagename;
                var finalNews = AutoMapperConfig.mapper.Map<NewsViewModel, News>(newsViewModel);

                finalNews.IsActive = true;
                finalNews.Like = 0;
                finalNews.See = 0;
                finalNews.RegisterDate = DateTime.Now;

                _newsService.Add(finalNews);
                _newsService.Save();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.authors, "AuthorId", "Mobilenumber", newsViewModel.AuthorId);
            ViewBag.NewsGroupId = new SelectList(db.newsGroups, "NewsGroupId", "NewsGroupTitle", newsViewModel.NewsGroupId);
            return View(newsViewModel);
        }

        // GET: Admin/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = _newsService.GetEntity(id.Value);
            if (news == null)
            {
                return HttpNotFound();
            }
            NewsViewModel newsViewModel = AutoMapperConfig.mapper.Map<News, NewsViewModel>(news);
            ViewBag.AuthorId = new SelectList(db.authors, "AuthorId", "Mobilenumber", news.AuthorId);
            ViewBag.NewsGroupId = new SelectList(db.newsGroups, "NewsGroupId", "NewsGroupTitle", news.NewsGroupId);
            return View(newsViewModel);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsId,NewsTitle,NewsDescription,ImageName,RegisterDate,IsActive,See,Like,NewsGroupId,AuthorId,BaseDescription")]
                                    NewsViewModel newsViewModel, HttpPostedFileBase imgupload)
        {
            if (ModelState.IsValid)
            {
                if (newsViewModel.ImageName != "Null.png" && imgupload != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/Images/News/" + newsViewModel.ImageName));
                    string imgName = Guid.NewGuid().ToString().Replace("-", " ") + Path.GetExtension(imgupload.FileName);
                    imgupload.SaveAs(Server.MapPath("~/Images/News/") + imgName);

                    newsViewModel.ImageName = imgName;
                }


                News finalNews = AutoMapperConfig.mapper.Map<NewsViewModel, News>(newsViewModel);
                _newsService.Update(finalNews);
                _newsService.Save();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.authors, "AuthorId", "Mobilenumber", newsViewModel.AuthorId);
            ViewBag.NewsGroupId = new SelectList(db.newsGroups, "NewsGroupId", "NewsGroupTitle", newsViewModel.NewsGroupId);
            return View(newsViewModel);
        }

        // GET: Admin/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = _newsService.GetEntity(id.Value);
            if (news == null)
            {
                return HttpNotFound();
            }
            NewsViewModel nvm = AutoMapperConfig.mapper.Map<News,NewsViewModel>(news);
            return View(nvm);
        }

        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = _newsService.GetEntity(id);
            if (news.ImageName!="Null.png")
            {
                System.IO.File.Delete(news.ImageName);
            }
            _newsService.Delete(news);
            _newsService.Save();
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
