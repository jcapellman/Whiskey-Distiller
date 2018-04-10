using System.Windows.Input;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;
using WhiskeyDistiller.library.Views;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class MainGamePageVM : BaseVM
    {
        private Game _currentGame;

        public Game CurrentGame
        {
            get { return _currentGame; }
            set { _currentGame = value; OnPropertyChanged("CurrentGame"); }
        }

        public ICommand ShowOptionsCommand => NavigateCommand<InGameMenuPage>();

        public ICommand GotoWarehouseCommand => NavigateCommand<WarehousePage>();

        public ICommand GotoEventsCommand => NavigateCommand<EventsPage>();

        public ICommand GotoBatchCommand => NavigateCommand<BatchPage>();

        public ICommand GotoFinancialsCommand => NavigateCommand<FinancialsPage>();

        public MainGamePageVM(INavigation navigation) : base(navigation)
        {
            CurrentGame = IoC.GameManager.CurrentGame;
        }

        public ICommand NextTurnCommand => new Command(() =>
        {
            IoC.GameManager.ComputeTurn();

            CurrentGame = IoC.GameManager.CurrentGame;
        });
    }
}