using dam.mvvm.sqlite.View;

namespace dam.mvvm.sqlite
{
    public partial class MainPage : ContentPage
    {
       
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Registrate_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void TieneUnaCuenta_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }

}
