using dam.mvvm.sqlite.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dam.mvvm.sqlite.Datos
{
    public class PersonasAdmin
    {
        SQLiteAsyncConnection cnn;
        public PersonasAdmin(string ruta)
        {
            cnn = new SQLiteAsyncConnection(ruta);
            cnn.CreateTableAsync<PersonasModel>().Wait();
        }

        public Task<int> Guardar(PersonasModel modelo)
        {
            if (modelo.ID == 0)
            {
                return cnn.InsertAsync(modelo);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<PersonasModel>> Consultar()
        {
            return await cnn.Table<PersonasModel>().ToListAsync();
        }



    }
}
