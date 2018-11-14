using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.Views
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BindingContext = new MainPageVm(this.Navigation);
		}
	}
}