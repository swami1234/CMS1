using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS1.Model
{    
    [Table("Roles")] //table attribute
    public class RoleModal
    {
        public int Id { get; set; }
        [Required] // not null in database
        public string Name { get; set; }

        //navigation properties
        public ICollection<UserModal>Users { get; set; } //EF will create many to many relationship
    }
}
