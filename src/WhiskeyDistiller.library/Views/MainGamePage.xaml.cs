using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.Views
{
	public partial class MainGamePage : ContentPage
	{
        private MainGamePageVm ViewModel => (MainGamePageVm)BindingContext;

		public MainGamePage ()
		{
			InitializeComponent ();

            BindingContext = new MainGamePageVm(Navigation);
		}
	}
}