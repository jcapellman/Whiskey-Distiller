using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.Views
{
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