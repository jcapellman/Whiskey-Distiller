using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhiskeyDistiller.library.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SavePage : ContentPage
	{
		public SavePage ()
		{
			InitializeComponent ();

            BindingContext = new SavePageVM(Navigation);
		}
	}
}