using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dam.mvvm.sqlite.Model;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace dam.mvvm.sqlite.ViewModel
{
    class RegistroViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string usuario;
        private string password;
        private string email;
        private DatabaseContext dbContext;

        public string Usuario
        {
            get => usuario;
            set
            {
                usuario = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegistrarComando { get; }
        public ICommand NavegarLoginComando { get; }

        public RegistroViewModel()
        {
            dbContext = new DatabaseContext("usuarios.db3");
            RegistrarComando = new Command(async () => await Registrar());
            NavegarLoginComando = new Command(NavegarLogin);
        }

        private async Task Registrar()
        {
            if (string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Todos los campos son obligatorios", "Aceptar");
                return;
            }

            var usuarioModel = new UsuarioModel { Usuario = Usuario, Password = Password, Email = Email };
            await dbContext.Guardar(usuarioModel);
            await App.Current.MainPage.DisplayAlert("Éxito", "Usuario registrado correctamente", "Aceptar");
        }

        private async void NavegarLogin()
        {
            await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
