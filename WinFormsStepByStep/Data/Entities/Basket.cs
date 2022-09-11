using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsStepByStep.Data.Entities
{
    [Table("tblBaskets")]
    public class Basket
    {
        [Key]
        public int Id { get; set; }
        public int Count { get; set; }
        [ForeignKey("ProductOf")]
        public int ProductId { get; set; }
        [ForeignKey("UserOf")]
        public int UserId { get; set; }
        public virtual Product ProductOf { get; set; }
        public virtual User UserOf { get; set; }

    }
}
