using WhiskeyDistiller.library.Views;

using Xamarin.Forms;

namespace WhiskeyDistiller.library
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}
	}
}