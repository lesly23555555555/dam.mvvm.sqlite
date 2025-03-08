using dam.mvvm.sqlite.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dam.mvvm.sqlite.Services
{
    class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Users.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Usuario>().Wait();
        }

        // ✅ Agregar un usuario a la base de datos
        public Task<int> AddUser(Usuario user)
        {
            return _database.InsertAsync(user);
        }

        // ✅ Buscar usuario por email
        public Task<Usuario> GetUserByEmail(string email)
        {
            return _database.Table<Usuario>().Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        // ✅ Buscar usuario por credenciales (Login)
        public Task<Usuario> GetUserByCredentials(string email, string password)
        {
            return _database.Table<Usuario>().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
        }

        internal async Task AddUsuario(Usuario newUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
