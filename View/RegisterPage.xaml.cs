using dam.mvvm.sqlite.ViewModel;
using Microsoft.Maui.Controls;
using System; 

namespace dam.mvvm.sqlite.View;

public partial class RegisterPage : ContentPage
{
    public RegistroViewModel ViewModel { get; set; }
    
    public RegisterPage()
    {
        InitializeComponent();
        ViewModel = new RegistroViewModel();
        BindingContext = ViewModel;
    }

    private void OnRegisterClicked(object sender, EventArgs e)
    {
        // Llamar a la lógica del ViewModel para registrar al usuario
        ViewModel.Register();
    }
}
  