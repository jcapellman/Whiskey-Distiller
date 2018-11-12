using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhiskeyDistiller.library.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventsPage : ContentPage
	{
		public EventsPage ()
		{
			InitializeComponent ();

            BindingContext = new EventsPageVm(Navigation);
		}
	}
}