using App.Pichanguea.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Pichanguea.Controllers
{
    public class LoginController : Controller
    {
        private Usuario usuario = new Usuario();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Validar(string nombre , string contrasena)
        {
            Debug.WriteLine(nombre + "-"+contrasena);
            var rm = usuario.Validar(nombre, contrasena);
            if (rm.response)
            {
                rm.href = Url.Content("~/Home");
            }
            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Login");
        }
    }
}