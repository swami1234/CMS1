using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Web.ViewModels;
using CMS1.Data.Interfaces;
using CMS1.Model;

namespace CMS.Web.Areas.Admin.Controllers
{
   
    public class SidebarController : Controller
    {

        private readonly IUnitOfWork _uow;

        public SidebarController(IUnitOfWork uow)
        {
            _uow = uow; // in uow we will have object at runtime
        }

        // GET: Admin/Sidebar
        [HttpGet]
        public ActionResult Index()
        {

            var sidebars = _uow.SideBarRepository.GetAll();

            List<SidebarViewModel> ViewModel = new List<SidebarViewModel>();

            foreach(var sidebar in sidebars)
            {
                ViewModel.Add(new SidebarViewModel()
                {
                    Id = sidebar.Id,
                    Name = sidebar.Name,
                    Content = sidebar.Content
                });
            }


            return View(ViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SidebarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Sidebar sidebar = new Sidebar
                {
                    Name = viewModel.Name,
                    Content = viewModel.Content
                };
                _uow.SideBarRepository.Create(sidebar);
                _uow.Commit();

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sidebar = _uow.SideBarRepository.GetById(id);

            SidebarViewModel viewModel = new SidebarViewModel()
            {
                Id = sidebar.Id,
                Name = sidebar.Name,
                Content = sidebar.Content
            };

            return View(viewModel);
               
        }

        [HttpPost]
        public ActionResult Edit(SidebarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var sidebar = _uow.SideBarRepository.GetById(viewModel.Id);

                sidebar.Name = viewModel.Name;
                sidebar.Content = viewModel.Content;

                _uow.SideBarRepository.Update(sidebar);
                _uow.Commit();

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var sidebar = _uow.SideBarRepository.GetById(id);

            SidebarViewModel viewModel = new SidebarViewModel()
            {
                Id = sidebar.Id,
                Name = sidebar.Name,
                Content = sidebar.Content
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(SidebarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var sidebar = _uow.SideBarRepository.GetById(viewModel.Id);

                sidebar.Name = viewModel.Name;
                sidebar.Content = viewModel.Content;

                _uow.SideBarRepository.Update(sidebar);
                _uow.Commit();

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }
    }
}
