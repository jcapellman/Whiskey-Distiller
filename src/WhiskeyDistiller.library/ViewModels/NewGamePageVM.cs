﻿using System.Windows.Input;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.Views;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class NewGamePageVm : BaseVm
    {
        private string _distillerName;

        public string DistillerName
        {
            get => _distillerName;
            set
            {
                _distillerName = value;
                OnPropertyChanged(nameof(DistillerName));

                CheckForm();
            }
        }

        private string _playerName;

        public string PlayerName
        {
            get => _playerName;

            set {
                _playerName = value;
                OnPropertyChanged(nameof(PlayerName));

                CheckForm();
            }
        }

        private void CheckForm()
        {
            EnableStartGameButton = !string.IsNullOrEmpty(PlayerName) && !string.IsNullOrEmpty(DistillerName);
        }

        private bool _enableStartGameButton;

        public bool EnableStartGameButton
        {
            get => _enableStartGameButton;
            set { _enableStartGameButton = value; OnPropertyChanged(nameof(EnableStartGameButton)); }
        }

        public ICommand StartGameCommand {
            get
            {
                var result = IoC.GameManager.CreateNewGame(DistillerName, PlayerName);

                return result ? NavigateCommand<MainGamePage>() : NavigateCommand<ErrorPage>();
            }
        }

        public NewGamePageVm(INavigation navigation) : base(navigation) { }

        public void InitForm()
        {
            PlayerName = string.Empty;
            DistillerName = string.Empty;

            CheckForm();
        }
    }
}