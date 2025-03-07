using dam.mvvm.sqlite.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dam.mvvm.sqlite.ViewModel
{
    internal class ListadoPersonasViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<PersonasModel> personas;
        public ObservableCollection<PersonasModel> Personas4 //Esta es la propiedad Personas que alimenta al ListView
        {
            get { return personas; }
            set { personas = value; OnPropertyChanged(); }
        }
        public async void Consultar()
        {
            IEnumerable<PersonasModel> lista = await App.Contexto.Consultar();
            Personas4 = new ObservableCollection<PersonasModel>(lista); //Aqui traé el listado desde la base de datos
        }
        public ListadoPersonasViewModel()
        {
            Consultar();
        }
    }
}
