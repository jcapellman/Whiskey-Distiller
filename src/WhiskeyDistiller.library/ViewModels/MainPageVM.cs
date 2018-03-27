using System.Windows.Input;

using Xamarin.Forms;

using WhiskeyDistiller.library.Views;

namespace WhiskeyDistiller.library.ViewModels
{
    public class MainPageVM : BaseVM
    {
        public ICommand NewGameCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigateToAsync<NewGamePage>();
                });
            }
        }

        public ICommand LoadGameCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigateToAsync<LoadGamePage>();
                });
            }
        }

        public ICommand OptionsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigateToAsync<OptionsPage>();
                });
            }
        }

        public ICommand AboutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigateToAsync<AboutPage>();
                });
            }
        }

        public MainPageVM(INavigation navigation) : base(navigation)
        {         
        }
    }
}