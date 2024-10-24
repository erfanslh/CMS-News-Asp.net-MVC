using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CMSNachrichtModel.Model;

namespace CMSNachricht.Models.ViewModel
{
    public class NewsGroupViewModel
    {
         
        public int NewsGroupId { get; set; }
        [Display(Name = "Titel")]
        public string NewsGroupTitle { get; set; }
        [Display(Name = "Foto")]
        public string NewsGroupImage { get; set; }

        //FK
        public ICollection<News> FkNews { get; set; }
    }
}