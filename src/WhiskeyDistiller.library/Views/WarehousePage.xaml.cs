using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhiskeyDistiller.library.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WarehousePage : ContentPage
	{
		public WarehousePage ()
		{
			InitializeComponent ();

            BindingContext = new WarehousePageVM(Navigation);
		}
	}
}