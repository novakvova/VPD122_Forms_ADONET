using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWinForms.Data
{
    [Table("tblUserRoles")]
    public class AppUserRole
    {
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }
        public int RoleId { get; set; }
        public virtual AppRole Role { get; set; }
    }
}
