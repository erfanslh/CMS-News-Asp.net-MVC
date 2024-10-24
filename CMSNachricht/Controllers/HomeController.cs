using CMSNachricht.Models.ViewModel;
using CMSNachrichtModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.App_Start;
using CMSNachrichtModel.Context;
using CMSNachrichtService.Service;
using CMSNachricht.App_Start;

namespace CMSNachricht.Controllers
{
    public class HomeController : Controller
    {
        DbNachrichtContext db = new DbNachrichtContext();
        NewsService _newsService;
        NewsGroupService _newsgroupService;

        public HomeController()
        {
            _newsService = new NewsService(db);
            _newsgroupService = new NewsGroupService(db);
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult mySlider(int? count)
        {
            var getallNews = _newsService.mySlider();
            var lastNewsSlider = getallNews.ToNewsViewModels();
            return PartialView(lastNewsSlider);
        }
        public ActionResult _newsgroupFatures(int count)
        {
            var getallNews = _newsService.newsgroupFatures(count);
            var LastNG = getallNews.ToNewsViewModels();
            return PartialView(LastNG);
        }
        public ActionResult _mostViewedPosts(int count)
        {
            var getallNews = _newsService.mostView(count);
            var LastNw = getallNews.ToNewsViewModels();
            return PartialView(LastNw);
        }

        public ActionResult lastNews()
        {
            var getLastNews = _newsService.getLastNews();
            var conv = getLastNews.ToNewsViewModel();
            return PartialView(conv);
        }
        public ActionResult _mostLikedPost(int count)
        {
            var allNews = _newsService.mostLiked(count);
            var map = allNews.ToNewsViewModels();
            return PartialView(map);
        }
        public ActionResult navMenu()
        {
            return PartialView();
        }

        public ActionResult _socialMedia()
        {
            return PartialView();
        }

        /// <summary>
        /// Take two last news in Tech-Category
        /// </summary>
        /// <returns>2 Last News in Technology</returns>
        public ActionResult _whatisNews()
        {
            var lastTech = _newsService.getTwoTechNews();
            var map = lastTech.ToNewsViewModels();
            return PartialView(map);
        }

        public ActionResult newsDetail(int id)
        {
            var getNews = _newsService.GetEntity(id);
            if (getNews == null || !getNews.IsActive)
            {
                return HttpNotFound();
            }
            getNews.See++;
            _newsService.Update(getNews);
            _newsService.Save();
            var map = getNews.ToNewsViewModel();
            return View(map);
        }

        public ActionResult ShowLike(int newsId, bool state)
        {
            var news = _newsService.GetEntity(newsId);
            NewsLikeViewModel newsLikeViewModel = new NewsLikeViewModel() {
                NewsId = newsId,
                Like = news.Like,
                NewsState = state
            };
            return PartialView(newsLikeViewModel);
        }
        public ActionResult ChangeLikeState(int newsId,bool state)
        {
            var news = _newsService.GetEntity(newsId);
            news.Like = (state) ? (news.Like - 1) : (news.Like + 1);
            _newsService.Update(news);
            _newsService.Save();

            return RedirectToAction("ShowLike",new { newsId, state });
        }
    }
}