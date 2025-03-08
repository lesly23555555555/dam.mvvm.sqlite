using System.ComponentModel;
using System.Windows.Input;
using dam.mvvm.sqlite.Services;
using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace dam.mvvm.sqlite.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private string _email;
        private string _password;

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        // Comandos
        public ICommand LoginCommand { get; }
        public ICommand GoToRegisterCommand { get; }
        public ICommand ForgotPasswordCommand { get; }

        // Comandos para mostrar alertas
        public ICommand ShowNewAccountAlertCommand { get; }
        public ICommand ShowForgotPasswordAlertCommand { get; }
        public ICommand ShowLoginAlertCommand { get; }

        public LoginViewModel()
        {
            // Inicialización de comandos
            LoginCommand = new Command(async () => await LoginAsync());
            GoToRegisterCommand = new Command(GoToRegister);
            ForgotPasswordCommand = new Command(ForgotPassword);

            // Comandos de alerta
            ShowNewAccountAlertCommand = new Command(ShowNewAccountAlert);
            ShowForgotPasswordAlertCommand = new Command(ShowForgotPasswordAlert);
            ShowLoginAlertCommand = new Command(ShowLoginAlert);
        }

        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes completar todos los campos", "OK");
                return;
            }

            // Aquí puedes agregar lógica de autenticación, por ahora solo lo mostramos en la consola.
            Debug.WriteLine($"Intento de inicio de sesión con: {Email}");

            await Application.Current.MainPage.DisplayAlert("Éxito", "Has iniciado sesión correctamente", "OK");
        }

        private void GoToRegister()
        {
            Debug.WriteLine("Navegando a la pantalla de registro...");
            // Aquí iría la navegación a la pantalla de registro
        }

        private void ForgotPassword()
        {
            Debug.WriteLine("Redirigiendo a la recuperación de contraseña...");
            // Aquí puedes implementar la recuperación de contraseña
        }

        private async void ShowNewAccountAlert()
        {
            await Application.Current.MainPage.DisplayAlert("Nueva Cuenta", "Te redirigiré a la pantalla de registro.", "OK");
        }

        private async void ShowForgotPasswordAlert()
        {
            await Application.Current.MainPage.DisplayAlert("Recuperar Contraseña", "Te redirigiré a la pantalla para recuperar tu contraseña.", "OK");
        }

        private async void ShowLoginAlert()
        {
            await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Intentando iniciar sesión...", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}