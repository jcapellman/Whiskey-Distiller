﻿using WhiskeyDistiller.library.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhiskeyDistiller.library.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewGamePage : ContentPage
	{
        private NewGamePageVm viewModel => (NewGamePageVm)BindingContext;

		public NewGamePage ()
		{
			InitializeComponent ();

            BindingContext = new NewGamePageVm(Navigation);
		}

        protected override void OnAppearing()
        {
            viewModel.InitForm();
        }
    }
}