using Microsoft.Maui.Controls;
using System.ComponentModel;

using System.Threading.Tasks;
using dam.mvvm.sqlite.Models;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using dam.mvvm.sqlite.Services;
using System.Windows.Input;

namespace dam.mvvm.sqlite.ViewModel
{
  public  class RegistroViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly DatabaseService _databaseService;

        public  RegistroViewModel()
        {
            _databaseService = new DatabaseService();
            RegisterCommand = new Command(async () => await Register());
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand RegisterCommand { get; }

        public async Task Register()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            var user = new Usuario { Name = Name, Email = Email, Password = Password };
            await _databaseService.AddUser(user);

            await Application.Current.MainPage.DisplayAlert("Éxito", "Usuario registrado correctamente.", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void RegistrarUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
