using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dam.mvvm.sqlite.Models
{
    class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
