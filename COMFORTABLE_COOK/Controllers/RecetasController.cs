using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using COMFORTABLE_COOK.Models;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace COMFORTABLE_COOK.Controllers
{
    public class RecetasController : Controller
    {
        BaseDeDatos bd = new BaseDeDatos();
        public List<Receta> recetas;
        //COM-14 / Acceder a mi lista de recetas / RF5
        public ActionResult Index()
        {
            var recetas = bd.ConsultarRecetas(Convert.ToInt32(Session["user"]));

            return View(recetas);
        }

        //COM-17 / Acceder a mi lista de recetas / RF9
        [HttpGet]
        public ActionResult VerReceta(int idReceta)
        {
            var receta = bd.ConsultarRecetaPorId(idReceta);
            return View(receta);
        }
        //COM-16 / Añadir receta / RF6
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

        //COM-25 / Crear receta con speech to text / RF10
        [HttpGet]
        public async Task<SpeechRecognitionResult> SpeechToTextAction()
        {
            //await SpeechToText.SpeechToTextFeature();
            //var speechconfig = SpeechConfig.FromEndpoint(new Uri("https://eastus2.api.cognitive.microsoft.com/sts/v1.0/issuetoken"), "bbd5357e3c4c4c4997633ae0b463f531");
            var speechconfig = SpeechConfig.FromSubscription("bbd5357e3c4c4c4997633ae0b463f531", "eastus2");
            speechconfig.SpeechRecognitionLanguage = "es-MX";
            using (var audioconfig = AudioConfig.FromDefaultMicrophoneInput())
            {
                using (var recognizer = new SpeechRecognizer(speechconfig, audioconfig))
                {
                    return await recognizer.RecognizeOnceAsync();
                }
            }
        }

        //COM-19 / Editar receta / RF7
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

        //COM-21 / Borrar receta / RF8
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

        //COM-22 / Etiquetar receta / RNF1
        [HttpGet]
        public ActionResult Favoritas()
        {
            var recetasfav = bd.ConsultarRecetasFavoritas(Convert.ToInt32(Session["user"]));

            return View(recetasfav);
        }

        //COM-23 / Etiquetar receta / RNF2
        [HttpGet]
        public ActionResult MarcarFavorita(int idReceta)
        {
            var receta = bd.ConsultarRecetaPorId(idReceta);
            return View(receta);
        }

        [HttpPost]
        public ActionResult MarcarFavorita(Receta receta)
        {
            var recetaFav = bd.MarcarFavorito(receta.IdReceta);
            if (recetaFav == true)
            {
                return Redirect("/Recetas/Favoritas");
            }
            return View(receta);
        }

        //COM-24 / Etiquetar receta / RNF3
        [HttpGet]
        public ActionResult EliminarFavorito(int idReceta)
        {
            var receta = bd.ConsultarRecetaPorId(idReceta);
            return View(receta);
        }

        [HttpPost]
        public ActionResult EliminarFavorito(Receta receta)
        {
            var recetaFav = bd.EliminarFavorito(receta.IdReceta);
            if (recetaFav == true)
            {
                return Redirect("/Recetas/Favoritas");
            }
            return View(receta);

        }
    }
}