using dam.mvvm.sqlite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace dam.mvvm.sqlite.Services
{
    class Autenticacionservicios
    {
        private readonly DatabaseService _databaseService = new DatabaseService();

        public async Task<bool> RegisterUser(string name, string email, string password)
        {
            var existingUser = await _databaseService.GetUserByEmail(email);
            if (existingUser != null)
                return false;

            var newUsuario = new Usuario { Name = name, Email = email, Password = password };
            await _databaseService.AddUser(newUsuario);
            return true;
        }

        public async Task<Usuario> LoginUser(string email, string password)
        {
            var usuario = await _databaseService.GetUserByCredentials(email, password);
            return new Usuario { Name = usuario.Name, Email = usuario.Email, Password = usuario.Password };
        }
    } 
}
