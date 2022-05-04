﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace COMFORTABLE_COOK.Models
{
    public class Receta
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        private string nombre;
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        private string descripcion;
        private int idUsuario;
        private int idReceta;

        public Receta(string nombre, string descripcion, int idUsuario, int idReceta)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            IdUsuario = idUsuario;
            IdReceta = idReceta;
        }

        public Receta() { }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get=> descripcion; set => descripcion= value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int IdReceta { get => idReceta; set => idReceta = value; }
    }
}