using System.Windows.Input;

using Xamarin.Forms;

using WhiskeyDistiller.library.Views;

namespace WhiskeyDistiller.library.ViewModels
{
    public class InGameMenuPageVm : BaseVm
    {
        public ICommand GotoSaveGameCommand => NavigateCommand<SavePage>();

        public InGameMenuPageVm(INavigation navigation) : base(navigation)
        {
        }
    }
}