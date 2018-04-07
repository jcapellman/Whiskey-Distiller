using System.Collections.Generic;
using System.Windows.Input;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;

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

        private bool _popupOptionsVisible;

        public bool PopupOptionsVisible
        {
            get { return _popupOptionsVisible; }
            set { _popupOptionsVisible = value; OnPropertyChanged("PopupOptionsVisible"); }
        }

        private bool _popupSaveMenuVisible;

        public bool PopupSaveMenuVisible
        {
            get { return _popupSaveMenuVisible; }
            set { _popupSaveMenuVisible = value; OnPropertyChanged("PopupOptionsVisible"); }
        }

        private List<Release> _currentReleases;

        public List<Release> CurrentReleases
        {
            get { return _currentReleases; }
            set { _currentReleases = value; OnPropertyChanged("CurrentReleases"); }
        }

        public MainGamePageVM(INavigation navigation) : base(navigation)
        {
            PopupOptionsVisible = false;
            PopupSaveMenuVisible = false;

            CurrentGame = IoC.GameManager.CurrentGame;
        }

        public ICommand ShowOptionsCommand => new Command(() => PopupOptionsVisible = true);

        public ICommand NextTurnCommand => new Command(() =>
        {
            IoC.GameManager.ComputeTurn();

            CurrentGame = IoC.GameManager.CurrentGame;
        });

        public ICommand ReturnToGameCommand => new Command(() => PopupOptionsVisible = false);

        public ICommand ShowSaveMenuCommand => new Command(() => PopupSaveMenuVisible = true);
    }
}