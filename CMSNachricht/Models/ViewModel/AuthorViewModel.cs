using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CMSNachrichtModel.Model;

namespace CMSNachricht.Models.ViewModel
{
    public class AuthorViewModel
    {
        [Key]
        public int AuthorId { get; set; }
        [Required, MaxLength(15)]
        [Display(Name ="Telefon")]
        public string Mobilenumber { get; set; }
        [Required, DataType(DataType.Password), MinLength(8)]
        [Display(Name = "Kennwort")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Anmeldungsdatum")]
        public DateTime RegisterDate { get; set; }
        [Required]
        [Display(Name = "Status")]
        public bool IsActive { get; set; }

        //FK
        public virtual ICollection<News> FkNews { get; set; }
    }
}