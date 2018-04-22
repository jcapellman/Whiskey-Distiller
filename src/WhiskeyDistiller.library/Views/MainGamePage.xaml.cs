using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.Views
{
	public partial class MainGamePage : ContentPage
	{
        private MainGamePageVM ViewModel => (MainGamePageVM)BindingContext;

		public MainGamePage ()
		{
			InitializeComponent ();

            BindingContext = new MainGamePageVM(Navigation);
		}
	}
}