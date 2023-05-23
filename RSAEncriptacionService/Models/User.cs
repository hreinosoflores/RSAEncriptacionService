using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSAEncriptacionService.Models
{
    public class User
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string pais { get; set; }
        public string ciudad { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string idUsuario { get; set; }
        public string contrasenha { get; set; }
    }
}
