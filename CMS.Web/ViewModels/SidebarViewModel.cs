using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.ViewModels
{
    public class SidebarViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required][AllowHtml]
        public string Content { get; set; }
    }
}