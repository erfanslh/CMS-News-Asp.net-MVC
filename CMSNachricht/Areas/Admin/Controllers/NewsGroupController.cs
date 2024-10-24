using CMSNachricht.Models.ViewModel;
using CMSNachrichtModel.Context;
using CMSNachrichtModel.Model;
using CMSNachrichtService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.App_Start;

namespace CMSNachricht.Areas.Admin.Controllers
{
    public class NewsGroupController : Controller
    {
        DbNachrichtContext db = new DbNachrichtContext();
        NewsGroupService _newsGroupService;
        public NewsGroupController()
        {
            _newsGroupService = new NewsGroupService(db);
        }
        public ActionResult Index()
        {
            var GetAll = _newsGroupService.GetAll().ToList();
            var finalList = AutoMapperConfig.mapper.Map<List<NewsGroup>, List<NewsGroupViewModel>>(GetAll);
            return View(finalList);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="NewsGroupTitle")] 
                                    NewsGroupViewModel newsGroupViewModel , HttpPostedFileBase imgupload)
        {
            if (ModelState.IsValid)
            {
                string imageName = "Null.png";
                if (imgupload != null)
                {
                    imageName = Guid.NewGuid().ToString().Replace("-", " ") + System.IO.Path.GetExtension(imgupload.FileName);
                    imgupload.SaveAs(Server.MapPath("~/Images/NewsGroup/") + imageName);
                }
                newsGroupViewModel.NewsGroupId = _newsGroupService.NextNewsGroupId();
                newsGroupViewModel.NewsGroupImage = imageName;
                var newsGroup = AutoMapperConfig.mapper.Map<NewsGroupViewModel, NewsGroup>(newsGroupViewModel);
                _newsGroupService.Add(newsGroup);
                _newsGroupService.Save();

                return RedirectToAction("Index");
            }
            return View(newsGroupViewModel);
        }


        public ActionResult Edit(int? id)
        {
            if (id== null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            NewsGroup newsGroup = _newsGroupService.GetEntity(id.Value);
            if (newsGroup == null)
            {
                return HttpNotFound();
            }
            var newsGroupVM = AutoMapperConfig.mapper.Map<NewsGroup, NewsGroupViewModel>(newsGroup);
            return View(newsGroupVM);

        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="NewsGroupId,NewsGroupTitle,NewsGroupImage")]
                                    NewsGroupViewModel newsGroupViewModel, HttpPostedFileBase imgupload)
        {
                if (imgupload != null)
                {
                    if (newsGroupViewModel.NewsGroupImage != "Null.png")
                    {
                        System.IO.File.Delete(Server.MapPath("~/Images/NewsGroup/") + newsGroupViewModel.NewsGroupImage);
                        newsGroupViewModel.NewsGroupImage = Guid.NewGuid().ToString().Replace("-", " ") + System.IO.Path.GetExtension(imgupload.FileName);
                        imgupload.SaveAs(Server.MapPath("~/Images/NewsGroup/") + newsGroupViewModel.NewsGroupImage);
                    }
                    else
                    {
                    newsGroupViewModel.NewsGroupImage = Guid.NewGuid().ToString().Replace("-", " ") + System.IO.Path.GetExtension(imgupload.FileName);
                    imgupload.SaveAs(Server.MapPath("~/Images/NewsGroup/") + newsGroupViewModel.NewsGroupImage);
                    }
                    
                }

                NewsGroup ng = AutoMapperConfig.mapper.Map<NewsGroupViewModel, NewsGroup>(newsGroupViewModel);
                _newsGroupService.Update(ng);
                _newsGroupService.Save();
                return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            NewsGroup newsGroup = _newsGroupService.GetEntity(id.Value);
            if (newsGroup == null)
            {
                return HttpNotFound();
            }
            var newsGroupVM = AutoMapperConfig.mapper.Map<NewsGroup, NewsGroupViewModel>(newsGroup);
            return View(newsGroupVM);
        }

        [HttpPost,ValidateAntiForgeryToken,ActionName("Delete")]
        public ActionResult Deleteconfirm(int? id)
        {
            var imageEntity = _newsGroupService.GetEntity(id.Value);
             if (imageEntity.NewsGroupImage != "Null.png")
            {
                System.IO.File.Delete(Server.MapPath("~/Images/NewsGroup/") + imageEntity.NewsGroupImage);
            }
            _newsGroupService.Delete(id.Value);
            _newsGroupService.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            NewsGroup newsGroup = _newsGroupService.GetEntity(id.Value);
            if (newsGroup == null)
            {
                return HttpNotFound();
            }
            var ngvm = AutoMapperConfig.mapper.Map<NewsGroup, NewsGroupViewModel>(newsGroup);
            return View(ngvm);
        }
    }
           
    }