using System.Windows.Input;

using WhiskeyDistiller.library.Views;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class MainGamePageVM : BaseVM
    {
        public MainGamePageVM(INavigation navigation) : base(navigation)
        {
        }

        public ICommand OptionsCommand => NavigateCommand<MainPage>();
        
        public ICommand NextTurnCommand => NavigateCommand<MainPage>();
    }
}