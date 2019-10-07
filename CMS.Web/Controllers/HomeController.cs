using CMS.Web.ViewModels;
using CMS1.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _uow;

        public HomeController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: Admin/Home
        public ActionResult Index(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                slug = "home";

            if (!_uow.PageRepository.SlugExists(slug))
                return RedirectToAction(nameof(Index), new { slug = "" });

            var pageFromDb = _uow.PageRepository.GetPageBySlug(slug);

            ViewBag.PageTitle = pageFromDb.Title;
            TempData["PageTitle"] = pageFromDb.Title;
            TempData["SidebarId"] = pageFromDb.SidebarId;

            if (pageFromDb.IsSidebarVisible)
                ViewBag.sidebar = true;
            else
                ViewBag.sidebar = false;

            PageViewModel viewModel = new PageViewModel
            {
                Id = pageFromDb.Id,
            Title = pageFromDb.Title,
            Content = pageFromDb.Content
        };

            return View(viewModel);
        }

        [ChildActionOnly]
        public ActionResult PagesMenuPartial()
        {
            var pages = _uow.PageRepository.GetPageMenu();

            List<MenuViewModel> viewModel = new List<MenuViewModel>();

            foreach(var page in pages)
            {
                viewModel.Add(new MenuViewModel
                {
                    Title = page.Title,
                    Slug = page.Slug
                });
            }

            return PartialView(viewModel);

        }
        [ChildActionOnly]
        public ActionResult SidebarPartial()
        {
            int id = (int)TempData["SidebarId"];

            var sidebar = _uow.SideBarRepository.GetById(id);

            SidebarViewModel viewModel = new SidebarViewModel
            {
                Id = sidebar.Id,
                Name = sidebar.Name,
                Content = sidebar.Content
            };
            return PartialView(viewModel);
        }
    }
}