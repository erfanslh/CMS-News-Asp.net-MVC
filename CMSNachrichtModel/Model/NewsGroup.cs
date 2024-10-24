using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSNachrichtModel.Model
{
    [Table("T_NewsGroup")]
    public class NewsGroup : BaseEntity
    {
        [Key,Required,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NewsGroupId { get; set; }
        [Required]
        public string NewsGroupTitle { get; set; }
        [Required]
        public string NewsGroupImage { get; set; }

        //FK
        public virtual ICollection<News> FkNews { get; set; }
    }
}
