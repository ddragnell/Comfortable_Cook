using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMFORTABLE_COOK.Models
{
    public class Usuario
    {
        private string correo;
        private string contraseña;
        private string confirmcontr;

        public Usuario(string correo, string contraseña, string confirmcontr)
        {
            this.Correo = correo;
            this.Contraseña = contraseña;
            this.Confirmcontr = confirmcontr;
        }

        public string Correo { get => correo; set => correo = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Confirmcontr { get => confirmcontr; set => confirmcontr = value; }
    }
}