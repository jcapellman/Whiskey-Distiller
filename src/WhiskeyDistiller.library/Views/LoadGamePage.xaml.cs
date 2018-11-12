using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhiskeyDistiller.library.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadGamePage : ContentPage
	{
		public LoadGamePage ()
		{
			InitializeComponent ();

            BindingContext = new LoadGamePageVm(Navigation);
		}
	}
}