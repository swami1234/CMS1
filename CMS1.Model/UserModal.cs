using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS1.Model
{
    [Table("Users")]
   public class UserModal
    {
        public int id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        //navigation properties
        public ICollection<RoleModal> Roles { get; set; } //EF will create many to many relationship
    }
}
