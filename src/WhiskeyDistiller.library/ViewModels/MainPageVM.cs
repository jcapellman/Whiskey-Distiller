using System.Windows.Input;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class MainPageVM : BaseVM
    {
        public ICommand NewGameCommand { get; private set; }

        public MainPageVM()
        {
            NewGameCommand = new Command(NewGame);
        }

        public void NewGame()
        {
            IoC.Database.Add(new Games
            {
                Name = "Awesome Game",
                Cash = 1000,
                GameQuarter = 1,
                GameYear = 2018
            });
        }
    }
}