using dam.mvvm.sqlite.Datos;
using dam.mvvm.sqlite.View;

namespace dam.mvvm.sqlite
{
    public partial class App : Application
    {

        // Aqui creamos la base de datos
        static PersonasAdmin db;
        public static PersonasAdmin Contexto
        {
            get
            {
                if (db == null)
                {                       //Esta es la ruta donde se crea la base de datos dentro del telefono 
                    db = new PersonasAdmin(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mauimvvm.db3"));
                }
                return db;
            }


        }


        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
           // MainPage = new NavigationPage(new PersonasView());
        }
    }
}
