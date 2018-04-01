using System.Windows.Input;
using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;
using WhiskeyDistiller.library.Views;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class MainGamePageVM : BaseVM
    {
        public Game CurrentGame
        {
            get { return IoC.GameManager.CurrentGame; }
            set { OnPropertyChanged("CurrentGame"); }
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
        
        public MainGamePageVM(INavigation navigation) : base(navigation)
        {
            PopupOptionsVisible = false;
            PopupSaveMenuVisible = false;
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