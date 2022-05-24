using COMFORTABLE_COOK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COMFORTABLE_COOK.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        // COM-11 / Crear un usuario / RF1
        public ActionResult Index()
        {
            return View();
        }

        //COM-13 / Acceder a mi cuenta / RF1
        [HttpPost]
        public ActionResult Index(Usuario user)
        {
            BaseDeDatos bd = new BaseDeDatos();
            var existeUsuario = bd.Autenticado(user.Correo, user.Clave);
            if (existeUsuario != null)
            {
                Session["user"] = existeUsuario.IdUsuario;
                return Redirect("/Recetas/Index");
            }
            return View(user);
        }

        //COM-12 / Crear un usuario / RF2
        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(Usuario user)
        {
            BaseDeDatos bd = new BaseDeDatos();
            var existeUsuario = bd.GuardarUsuario(user.Correo, user.Clave);
            return View(user);
        }
        //COM-15 / Cerrar sesión / RF3
        public ActionResult CerrarSesion()
        {
            return Redirect("/Usuario/Index");
        }


    }
}