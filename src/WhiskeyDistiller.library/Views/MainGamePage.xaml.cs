using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhiskeyDistiller.library.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainGamePage : ContentPage
	{
        private MainGamePageVM viewModel => (MainGamePageVM)BindingContext;

		public MainGamePage ()
		{
			InitializeComponent ();

            BindingContext = new MainGamePageVM(Navigation);
		}
	}
}