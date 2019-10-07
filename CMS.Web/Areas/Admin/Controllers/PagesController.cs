using CMS.Web.ViewModels;
using CMS1.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS1.Services;
using CMS1.Model;

namespace CMS.Web.Areas.Admin.Controllers
{
   
    public class PagesController : Controller
    {

        private readonly IUnitOfWork _uow;

        public PagesController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: Admin/Pages
        [HttpGet]
        public ActionResult Index()
        {
            var pages = _uow.PageRepository.GetPagesWithSidebar();
            List<PageViewModel> viewModel = new List<PageViewModel>();

            foreach(var page in pages)
            {
                viewModel.Add(new PageViewModel()
                {
                    Id = page.Id,
                    Title = page.Title,
                    Slug = page.Slug,
                    Content = page.Content,
                    IsSidebarVisible = page.IsSidebarVisible,
                    IsVisibleInMenu = page.IsVisibleInMenu,
                    SidebarId = page.SidebarId,
                    Sidebar = page.Sidebar

                });
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult CreatePage()
        {

            ViewBag.SidebarDropDownList = _uow.SideBarRepository.GetAll();

            return View();
        }

        [HttpPost]
        public ActionResult CreatePage(PageViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SideBarDropDownList = _uow.SideBarRepository.GetAll();
                return View(viewModel);
            }

            string slug;

            Page page = new Page();
            page.Title = viewModel.Title;

            if(string.IsNullOrEmpty(viewModel.Slug))
            {
                slug = SlugHelper.Create(true, viewModel.Title);
            }

            else
            {
                slug = SlugHelper.Create(true, viewModel.Slug);
            }

            if(_uow.PageRepository.SlugExists(slug))
            {

                ModelState.AddModelError("", "Title or slug already exists");

                ViewBag.sideBarDropDownList = _uow.SideBarRepository.GetAll();
                return View(viewModel);
            }

            page.Slug = slug;
            page.Content = viewModel.Content;
            page.IsSidebarVisible = viewModel.IsSidebarVisible;
            page.IsVisibleInMenu = viewModel.IsVisibleInMenu;

            page.SidebarId = viewModel.SidebarId;

            _uow.PageRepository.Create(page);
            _uow.Commit();

            return RedirectToAction(nameof (Index));



        }

        [HttpGet]
        public ActionResult EditPage(int id)
        {
            var page = _uow.PageRepository.GetById(id);
            PageViewModel viewModel = new PageViewModel();

            viewModel.Id = page.Id;
            viewModel.Title = page.Title;
            viewModel.Slug = page.Slug;
            viewModel.Content = page.Content;
            viewModel.IsSidebarVisible = page.IsSidebarVisible;
            viewModel.IsVisibleInMenu = page.IsVisibleInMenu;
            viewModel.SidebarId = page.SidebarId;

            ViewBag.SidebarDropDownList = _uow.SideBarRepository.GetAll();

            return View(viewModel);


        }
         [HttpPost]
         public ActionResult EditPage(PageViewModel viewModel)
        {
            
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.SideBarDropDownList = _uow.SideBarRepository.GetAll();
                    return View(viewModel);
                }

                string slug;

                Page page = _uow.PageRepository.GetById(viewModel.Id);
                page.Title = viewModel.Title;

                if (string.IsNullOrEmpty(viewModel.Slug))
                {
                    slug = SlugHelper.Create(true, viewModel.Title);
                }

                else
                {
                    slug = SlugHelper.Create(true, viewModel.Slug);
                }

                if (_uow.PageRepository.SlugExists(viewModel.Id, slug))
                {

                    ModelState.AddModelError("", "Title or slug already exists");

                    ViewBag.sideBarDropDownList = _uow.SideBarRepository.GetAll();
                    return View(viewModel);
                }

                page.Slug = slug;
                page.Content = viewModel.Content;
                page.IsSidebarVisible = viewModel.IsSidebarVisible;
                page.IsVisibleInMenu = viewModel.IsVisibleInMenu;

                page.SidebarId = viewModel.SidebarId;

                _uow.PageRepository.Update(page);
                _uow.Commit();

                return RedirectToAction(nameof(Index));



            }
           
        }
    }
}