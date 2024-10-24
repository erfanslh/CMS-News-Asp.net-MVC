using CMSNachrichtModel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSNachricht.Models.ViewModel
{
    public class NewsViewModel
    {
        public int NewsId { get; set; }
        [MaxLength(100), Display(Name ="Titel")]
        public string NewsTitle { get; set; }
        [Display(Name="Description")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string NewsDescription { get; set; }
        [Display(Name = "Foto")]
        public string ImageName { get; set; }
        [Display(Name = "Datum")]
        [DisplayFormat(DataFormatString ="{0:dddd, dd MMMM yyyy}")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        [Display(Name = "Aufrufe")]
        public int See { get; set; }
        [Display(Name = "Gefallen")]
        public int Like { get; set; }

        //FK NewsGroup
        public int NewsGroupId { get; set; }
        public NewsGroup newsGroup { get; set; }

        //FK Author
        public int AuthorId { get; set; }
        public Author author { get; set; }

        //FK Comments
        public ICollection<Comment> comments { get; set; }
    }
}