using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace COMFORTABLE_COOK.Models
{
    public class Usuario
    {
        [Display(Name = "Correo")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        private string correo;
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        private string clave;
        private int idUsuario;

        public Usuario(string correo, string contraseña)
        {
            this.Correo = correo;
            this.Clave = clave;
        }
        public Usuario()
        {

        }
        public string Correo { get => correo; set => correo = value; }
        public string Clave { get => clave; set => clave = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
}



