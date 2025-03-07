using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dam.mvvm.sqlite.Model
{
   public  class DatabaseContext
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseContext(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UsuarioModel>().Wait();
        }

        public Task<int> Guardar(UsuarioModel usuario)
        {
            return _database.InsertAsync(usuario);
        }

        public Task<UsuarioModel> ObtenerUsuarioPorNombre(string usuario)
        {
            return _database.Table<UsuarioModel>().Where(x => x.Usuario == usuario).FirstOrDefaultAsync();
        }

        public Task<List<UsuarioModel>> ObtenerUsuarios()
        {
            return _database.Table<UsuarioModel>().ToListAsync();
        }
    }
}