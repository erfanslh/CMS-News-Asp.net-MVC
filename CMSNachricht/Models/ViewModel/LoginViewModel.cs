using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSNachricht.Models.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "Telefon")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }

    }
}