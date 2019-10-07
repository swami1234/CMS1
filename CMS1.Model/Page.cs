using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CMS1.Model
{
   public class Page
    {

        public int Id { get; set; }

        public string Title { get; set; }
            
        public string Slug { get; set; } //Url localhost/aboutme   aboutme goes in slug/Url

        public string Content { get; set; } //html

        public bool IsVisibleInMenu { get; set; }

        public bool IsSidebarVisible { get; set; } 

        public int SidebarId { get; set; } //relation between page and sidebar so creating a foriegn key "SidebarId"

        [ForeignKey("SidebarId")]
        public Sidebar Sidebar { get; set; } // navigation property //one to many relation in database
    }
}
