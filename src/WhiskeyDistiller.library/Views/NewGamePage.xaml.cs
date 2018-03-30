using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhiskeyDistiller.library.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewGamePage : ContentPage
	{
        private NewGamePageVM viewModel => (NewGamePageVM)BindingContext;

		public NewGamePage ()
		{
			InitializeComponent ();

            BindingContext = new NewGamePageVM(Navigation);
		}

        protected override void OnAppearing()
        {
            viewModel.InitForm();
        }
    }
}