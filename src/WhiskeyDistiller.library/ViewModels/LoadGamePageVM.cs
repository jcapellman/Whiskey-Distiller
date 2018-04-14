using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;
using WhiskeyDistiller.library.Views;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class LoadGamePageVM : BaseVM
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
            get { return _games; }
            set { _games = value; OnPropertyChanged("Games"); GamesListVisible = value.Any(); NoGamesFound = !value.Any(); }
        }

        public ICommand LoadGameCommand => new Command<Game>(async (game) =>
        {
            await _navigation.PushModalAsync((MainGamePage)Activator.CreateInstance(typeof(MainGamePage), game.ID));
        });

        public LoadGamePageVM(INavigation navigation) : base(navigation)
        {
            GamesListVisible = false;
            NoGamesFound = false;

            Games = IoC.GameManager.GetSavedGames();
        }
    }
}