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
            DisplayAlert("Error", " correo electrónico.", "OK");
            return;
        }

        DisplayAlert("Recuperación", "Se ha enviado un enlace de recuperación a su correo.", "OK");
    }
}