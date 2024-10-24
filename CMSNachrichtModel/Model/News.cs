using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSNachrichtModel.Model
{
    [Table("T_News")]
    public class News : BaseEntity
    {
        [Key,Required]
        public int NewsId { get; set; }
        [Required]
        public string NewsTitle { get; set; }
        [Required]
        public string NewsDescription { get; set; }
        [Required]
        public string ImageName { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int See { get; set; }
        [Required]
        public int Like { get; set; }

        //FK NewsGroup
        public int NewsGroupId { get; set; }
        public virtual NewsGroup newsGroup { get; set; }

        //FK Author
        public int AuthorId { get; set; }
        public virtual Author author { get; set; }

        //FK Comments
        public virtual ICollection<Comment> comments { get; set; }
    }
}
