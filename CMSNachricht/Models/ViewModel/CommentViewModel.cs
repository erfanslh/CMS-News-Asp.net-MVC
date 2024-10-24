using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CMSNachrichtModel.Model;

namespace CMSNachricht.Models.ViewModel
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        [Display(Name ="Kommentar")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Email Addresse")]
        public string Email { get; set; }
        [Display(Name = "Datum")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }

        //FK

        public int NewsId { get; set; }
        public virtual News news { get; set; }
    }
}