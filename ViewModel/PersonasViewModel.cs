using dam.mvvm.sqlite.Model;
using dam.mvvm.sqlite.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace dam.mvvm.sqlite.ViewModel
{
    public class PersonasViewModel : PersonasModel
    {
        public ICommand GuardarComando { get; set; }
        public ICommand ConsultarComando { get; set; }

        public PersonasViewModel()
        {
            GuardarComando = new Command(() => {
                PersonasModel modelo = new PersonasModel()
                {
                    ID = ID,
                    Nombre = Nombre,
                    Edad = Edad
                };
                Guardar(modelo);
            }
                );
            ConsultarComando = new Command(async () => {
                await Navegar();
            }

                );
        }

        public async void Guardar(PersonasModel modelo)
        {
            await App.Contexto.Guardar(modelo);
            await App.Current.MainPage.DisplayAlert("Asistente personas", "Guardar", "Aceptar");
        }
        public async Task Navegar()
        {
            await App.Current.MainPage.Navigation.PushAsync(new ListadoPersonasView());
        }
    }
}
