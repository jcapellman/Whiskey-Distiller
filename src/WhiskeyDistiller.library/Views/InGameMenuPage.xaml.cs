using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhiskeyDistiller.library.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InGameMenuPage : ContentPage
	{
		public InGameMenuPage ()
		{
			InitializeComponent ();

            BindingContext = new InGameMenuPageVM(Navigation);
		}
	}
}