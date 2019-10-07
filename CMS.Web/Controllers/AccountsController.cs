using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using CMS.Web.ViewModels;
using CMS1.Services;
using CMS1.Services.Security;

namespace CMS.Web.Areas.Admin.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Admin/Accounts


        private readonly IAuthenticationService _authenticationService;

        public AccountsController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = _authenticationService.Login(viewModel.UserName, viewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Login Attempt");
                return View(viewModel);
            }

            CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();

            serializeModel.Id = user.id;
            serializeModel.UserName = user.UserName;
            serializeModel.Email = user.Email;
            serializeModel.Roles = user.Roles.Select(x => x.Name).ToArray();

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string userData = serializer.Serialize(serializeModel);

            // Issuing a cookie

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddMinutes(30), false, userData);

            string encryptTicket = FormsAuthentication.Encrypt(authTicket);

            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
            faCookie.HttpOnly = true;
            faCookie.Secure = true; // make this true to make secure

            Response.Cookies.Add(faCookie);

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)

            {
                return View(viewModel);
            }

            bool registerstatus = _authenticationService.Register(viewModel.Email, viewModel.UserName, viewModel.Password);

            if (!registerstatus)
            {
                ModelState.AddModelError("", "userName already exists");
                return View(viewModel);
            }
            


            TempData["Success"] = "Registration Successful";
            return RedirectToAction(nameof(Login));

        }
    
    }
}