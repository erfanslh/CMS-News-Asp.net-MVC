using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSNachrichtModel.Model
{
    [Table("T_Comment")]
    public class Comment : BaseEntity
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public bool IsActive { get; set; }

        //FK

        public int NewsId { get; set; }
        public virtual News news { get; set; }
    }
}
