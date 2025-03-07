using System.ComponentModel;
using System.Windows.Input;
using dam.mvvm.sqlite.Services;
using System;

namespace dam.mvvm.sqlite.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private readonly EmailService _emailService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand OlvidoPasswordCommand { get; set; }

        public string Email { get; set; }

        public LoginViewModel()
        {
            _emailService = new EmailService();  // Instancia del servicio de correo
            OlvidoPasswordCommand = new Command(async () => await OlvidoPassword());
        }

        // Método para enviar correo de recuperación de contraseña
        public async Task OlvidoPassword()
        {
            if (string.IsNullOrEmpty(Email))
            {
                // Muestra un mensaje de error si el email está vacío
                await App.Current.MainPage.DisplayAlert("Error", "Por favor ingrese su correo", "Aceptar");
                return;
            }

            try
            {
                // Llama al servicio de correo para enviar el correo de recuperación
                await _emailService.EnviarCorreoRecuperacion(Email);
                await App.Current.MainPage.DisplayAlert("Correo Enviado", "Se ha enviado un correo de recuperación", "Aceptar");
            }
            catch (Exception ex)
            {
                // Manejo de errores
                await App.Current.MainPage.DisplayAlert("Error", "Hubo un error al enviar el correo: " + ex.Message, "Aceptar");
            }
        }
    }
}