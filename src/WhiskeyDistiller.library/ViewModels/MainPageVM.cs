using System.Windows.Input;

using Xamarin.Forms;

using WhiskeyDistiller.library.Views;

namespace WhiskeyDistiller.library.ViewModels
{
    public class MainPageVm : BaseVm
    {
        public ICommand NewGameCommand => NavigateCommand<NewGamePage>();

        public ICommand LoadGameCommand => NavigateCommand<LoadGamePage>();

        public ICommand OptionsCommand => NavigateCommand<OptionsPage>();

        public ICommand AboutCommand => NavigateCommand<AboutPage>();

        public MainPageVm(INavigation navigation) : base(navigation)
        {         
        }
    }
}