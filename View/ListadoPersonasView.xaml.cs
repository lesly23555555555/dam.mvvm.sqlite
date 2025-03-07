using dam.mvvm.sqlite.ViewModel;

namespace dam.mvvm.sqlite.View;

public partial class ListadoPersonasView : ContentPage
{
	public ListadoPersonasView()
	{
		InitializeComponent();
		BindingContext = new ListadoPersonasViewModel();
	}
}