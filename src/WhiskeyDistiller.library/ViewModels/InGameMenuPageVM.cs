using System.Windows.Input;

using Xamarin.Forms;

using WhiskeyDistiller.library.Views;

namespace WhiskeyDistiller.library.ViewModels
{
    public class InGameMenuPageVM : BaseVM
    {
        public ICommand GotoSaveGameCommand => NavigateCommand<SavePage>();

        public InGameMenuPageVM(INavigation navigation) : base(navigation)
        {
        }
    }
}