using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhiskeyDistiller.library.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WarehousePage : ContentPage
	{
	    private WarehousePageVm viewModel => (WarehousePageVm) BindingContext;

		public WarehousePage ()
		{
			InitializeComponent ();

            BindingContext = new WarehousePageVm(Navigation);
		}

	    private void Entry_OnTextChanged(object sender, TextChangedEventArgs e)
	    {
	        viewModel.WarehouseName = e.NewTextValue;
	    }
	}
}