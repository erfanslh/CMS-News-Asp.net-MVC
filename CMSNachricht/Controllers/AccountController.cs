using CMSNachricht.Models.ViewModel;
using CMSNachrichtModel.Context;
using CMSNachrichtService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CMSNachricht.Controllers
{
    public class AccountController : Controller
    {
        DbNachrichtContext db = new DbNachrichtContext();
        AuthorService _authorService;

        public AccountController()
        {
            _authorService = new AuthorService(db);
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login(string returnUrl = "/")
        {
            LoginViewModel lgvm = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };
            return View(lgvm);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Username,Password,RePassword,ReturnUrl,RememberMe")] LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var findUser = _authorService.GetAll().FirstOrDefault(t => t.Mobilenumber == loginViewModel.Username && t.Password == loginViewModel.Password);
                if (findUser != null)
                {
                    if (findUser.IsActive)
                    {
                        FormsAuthentication.SetAuthCookie(loginViewModel.Username, loginViewModel.RememberMe);
                        return Redirect(loginViewModel.ReturnUrl);
                    }
                    ModelState.AddModelError("Username", "Dein konnto ist von ADMIN gesperrt worden");
                }
            }
            ModelState.AddModelError("Username", "Das Telefonnummer ist nich vorhanden");
            return View(loginViewModel);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/Account/Index");
        }
    }
}