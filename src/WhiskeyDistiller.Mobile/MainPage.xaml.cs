﻿using WhiskeyDistiller.Mobile.ViewModels;

using Xamarin.Forms;

namespace WhiskeyDistiller.Mobile
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BindingContext = new MainPageVM();
		}
	}
}