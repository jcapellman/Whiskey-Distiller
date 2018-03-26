using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhiskeyDistiller.library.Views
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BindingContext = new MainPageVM(this.Navigation);
		}
	}
}