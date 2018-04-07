using System.Collections.Generic;
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

        public ICommand ShowOptionsCommand => NavigateCommand<OptionsPage>();

        private List<Release> _currentReleases;

        public List<Release> CurrentReleases
        {
            get { return _currentReleases; }
            set { _currentReleases = value; OnPropertyChanged("CurrentReleases"); }
        }

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