using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSNachrichtModel.Model
{
    [Table("T_Author")]
    public class Author : BaseEntity
    {
        [Key]
        public int AuthorId { get; set; }
        [Required, MaxLength(15)]
        public string Mobilenumber { get; set; }
        [Required, DataType(DataType.Password), MinLength(8)]
        public string Password { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public bool IsActive { get; set; }

        //FK
        public virtual ICollection<News> FkNews { get; set; }
    }
}
