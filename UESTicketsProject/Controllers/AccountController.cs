using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UESTicketsProject.Data.Entities;
using UESTicketsProject.Helpers;
using UESTicketsProject.Models;
using UESTicketsProject.Services.Interfaces;

namespace UESTicketsProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        private void LoginSuccess(Usuario usuario )
        {
            Session["UId"] = usuario.Id.ToString().ToBase64();
            Session["RoleId"] = usuario.RolId.ToString().ToBase64();

        }

        public ActionResult Logout()
        {
            var allDomainCookes = HttpContext.Request.Cookies.AllKeys;

            foreach (var domainCookie in allDomainCookes)
            {
                if (domainCookie.Contains("ASPXAUTH"))
                {
                    var expiredCookie = new HttpCookie(domainCookie)
                    {
                        Expires = DateTime.Now.AddDays(-1),
                        Domain = ".mydomain"
                    };
                    HttpContext.Response.Cookies.Add(expiredCookie);
                }
            }
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();
            HttpContext.Request.Cookies.Clear();
            return View("Login");
        }



        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginResponse(LoginModel model)
        {
            Usuario usuario;
            var x = _loginService.Login(model, out usuario);
            if (!x) return View("Login");
            LoginSuccess(usuario);
            return RedirectToAction("Dashboard","Usuario");
        }
    }
}