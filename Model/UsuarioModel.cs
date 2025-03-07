using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dam.mvvm.sqlite.Model
{
   public  class UsuarioModel
    {
        // La propiedad ID es la clave primaria y se incrementará automáticamente.
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        // Propiedad para el nombre de usuario.
        public string Usuario { get; set; }

        // Propiedad para la contraseña del usuario.
        public string Password { get; set; }

        // Propiedad para el correo electrónico del usuario.
        public string Email { get; set; }
    }
}
