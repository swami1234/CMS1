using CMS1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.ViewModels
{
    public class PageViewModel
    {

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Slug { get; set; }

        [Required][AllowHtml]
        public string Content { get; set; }

        public bool IsVisibleInMenu { get; set; }

        public bool IsSidebarVisible { get; set; }

        [Display(Name = "Sidebar Name")]
        public int SidebarId { get; set; }

        public Sidebar Sidebar { get; set; }
    }
}