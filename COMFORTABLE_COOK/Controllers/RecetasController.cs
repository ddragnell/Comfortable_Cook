using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COMFORTABLE_COOK.Models;

namespace COMFORTABLE_COOK.Controllers
{
    public class RecetasController : Controller
    {
        BaseDeDatos bd = new BaseDeDatos();
        public List<Receta>recetas;
        // GET: Recetas
        public ActionResult Index()
        {
            var recetas = bd.ConsultarRecetas(Convert.ToInt32(Session["user"]));

            return View(recetas);
        }

        [HttpGet]
        public ActionResult VerReceta(int idReceta)
        {
            var receta = bd.ConsultarRecetaPorId(idReceta);
            return View(receta);
        }

        [HttpGet]
        public ActionResult CrearReceta() {
            return View();
        }

        [HttpPost]
        public ActionResult CrearReceta(Receta receta)
        {
            receta.IdUsuario = Convert.ToInt32(Session["user"]);
            var guardarReceta = bd.GuardarReceta(receta.Nombre, receta.Descripcion, receta.IdUsuario);
            if (guardarReceta == true) {
                return Redirect("/Recetas/Index");
            }
            return View(receta);

        }

        [HttpGet]
        public ActionResult EditarReceta(int idReceta)
        {
            var receta = bd.ConsultarRecetaPorId(idReceta);
            return View(receta);
        }

        [HttpPost]
        public ActionResult EditarReceta(Receta receta)
        {
            var editarReceta = bd.EditarReceta(receta.Nombre, receta.Descripcion, receta.IdReceta);
            if (editarReceta == true)
            {
                return Redirect("/Recetas/Index");
            }
            return View(receta);

        }

        [HttpGet]
        public ActionResult EliminarReceta(int idReceta)
        {
            var receta = bd.ConsultarRecetaPorId(idReceta);
            return View(receta);
        }

        [HttpPost]
        public ActionResult EliminarReceta(Receta receta)
        {
            var eliminarReceta = bd.EliminarReceta(receta.IdReceta);
            if (eliminarReceta == true)
            {
                return RedirectToAction("Index");
            }
            return View(receta);

        }
    }
}