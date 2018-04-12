using System.Collections.Generic;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class LoadGamePageVM : BaseVM
    {
        private List<Game> _games;

        public List<Game> Games
        {
            get { return _games; }
            set { _games = value; OnPropertyChanged("Games"); }
        }

        public LoadGamePageVM(INavigation navigation) : base(navigation)
        {
            Games = IoC.GameManager.GetSavedGames();
        }
    }
}