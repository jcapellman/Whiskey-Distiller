using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class SavePageVm : BaseVm
    {
        private bool _gamesListVisible;

        public bool GamesListVisible
        {
            get => _gamesListVisible;

            private set
            {
                _gamesListVisible = value;
                OnPropertyChanged("GamesListVisible");
            }
        }

        private bool _noGamesFound;

        public bool NoGamesFound
        {
            get => _noGamesFound;

            private set
            {
                _noGamesFound = value;
                OnPropertyChanged("NoGamesFound");
            }
        }

        private List<Game> _games;

        public List<Game> Games
        {
            get => _games;
            set { _games = value; OnPropertyChanged("Games"); GamesListVisible = value.Any(); NoGamesFound = !value.Any(); }
        }

        private string _newSaveGameName;

        public string NewSaveGameName
        {
            get => _newSaveGameName;
            set { _newSaveGameName = value; OnPropertyChanged("NewSaveGameName"); }
        }

        public ICommand SaveGameCommand => new Command<Game>((obj) =>
        {
            IoC.GameManager.SaveNewGame(NewSaveGameName);
        });

        public ICommand OverwriteGameCommand => new Command<Game>((game) =>
        {
            IoC.GameManager.OverwriteSameGame(game);
        });

        public SavePageVm(INavigation navigation) : base(navigation)
        {
            GamesListVisible = false;
            NoGamesFound = false;

            Games = IoC.GameManager.GetSavedGames();
        }
    }
}