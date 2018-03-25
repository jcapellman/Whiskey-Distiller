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

        public MainPageVM(INavigation navigation) : base(navigation)
        {         
        }
    }
}