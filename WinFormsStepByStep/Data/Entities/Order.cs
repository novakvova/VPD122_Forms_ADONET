using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsStepByStep.Data.Entities
{
    [Table("tblOrders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreated{ get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public virtual OrderStatus Status { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
