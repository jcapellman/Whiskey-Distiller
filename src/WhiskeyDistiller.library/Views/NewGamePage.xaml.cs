using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhiskeyDistiller.library.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewGamePage : ContentPage
	{
		public NewGamePage ()
		{
			InitializeComponent ();

            BindingContext = new NewGameVM(Navigation);
		}
	}
}