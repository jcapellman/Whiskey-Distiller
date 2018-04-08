using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhiskeyDistiller.library.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BatchPage : ContentPage
	{
		public BatchPage ()
		{
			InitializeComponent ();

            BindingContext = new BatchPageVM(Navigation);
		}
	}
}