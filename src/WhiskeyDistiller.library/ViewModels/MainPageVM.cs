using System.Windows.Input;

using Xamarin.Forms;

using WhiskeyDistiller.library.Views;

namespace WhiskeyDistiller.library.ViewModels
{
    public class MainPageVM : BaseVM
    {
        public ICommand NewGameCommand => NavigateCommand<NewGamePage>();

        public ICommand LoadGameCommand => NavigateCommand<LoadGamePage>();

        public ICommand OptionsCommand => NavigateCommand<OptionsPage>();

        public ICommand AboutCommand => NavigateCommand<AboutPage>();

        public MainPageVM(INavigation navigation) : base(navigation)
        {         
        }
    }
}