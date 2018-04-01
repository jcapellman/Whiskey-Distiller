using System.Windows.Input;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.Views;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class NewGamePageVM : BaseVM
    {
        private string _distillerName;

        public string DistillerName
        {
            get { return _distillerName; }
            set { _distillerName = value; OnPropertyChanged("DistillerName"); CheckForm(); }
        }

        private string _playerName;

        public string PlayerName
        {
            get { return _playerName; }
            set { _playerName = value; OnPropertyChanged("PlayerName"); CheckForm(); }
        }

        private void CheckForm()
        {
            EnableStartGameButton = !string.IsNullOrEmpty(PlayerName) && !string.IsNullOrEmpty(DistillerName);
        }

        private bool _enableStartGameButton;

        public bool EnableStartGameButton
        {
            get { return _enableStartGameButton; }
            set { _enableStartGameButton = value; OnPropertyChanged("EnableStartGameButton"); }
        }

        public ICommand StartGameCommand {
            get
            {
                var result = IoC.GameManager.CreateNewGame(DistillerName);

                if (result)
                {
                    return NavigateCommand<MainGamePage>();
                }

                return NavigateCommand<ErrorPage>();
            }
        }

        public NewGamePageVM(INavigation navigation) : base(navigation) {
        }

        public void InitForm()
        {
            PlayerName = string.Empty;
            DistillerName = string.Empty;

            CheckForm();
        }
    }
}