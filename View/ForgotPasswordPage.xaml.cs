using Microsoft.Maui.Controls;
using System;
namespace dam.mvvm.sqlite.View;

public partial class ForgotPasswordPage : ContentPage
{
	public ForgotPasswordPage()
	{
		InitializeComponent();
	}

    private void Enviar_Clicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;

        if (string.IsNullOrEmpty(email))
        {
            DisplayAlert("Error", " correo electr�nico.", "OK");
            return;
        }

        DisplayAlert("Recuperaci�n", "Se ha enviado un enlace de recuperaci�n a su correo.", "OK");
    }
}