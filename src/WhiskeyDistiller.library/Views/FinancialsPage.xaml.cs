using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhiskeyDistiller.library.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FinancialsPage : ContentPage
	{
		public FinancialsPage ()
		{
			InitializeComponent ();

            BindingContext = new FinancialsPageVm(Navigation);
		}
	}
}