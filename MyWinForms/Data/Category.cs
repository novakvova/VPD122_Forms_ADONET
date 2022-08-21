using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWinForms.Data
{
    [Table("tblCategories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        [Required, StringLength(255)]
        public string Title { get; set; }
        public int Priority { get; set; }

        [ForeignKey("Parent")]
        public int ? ParentId { get; set; }
        public virtual Category Parent { get; set; }
    }
}
