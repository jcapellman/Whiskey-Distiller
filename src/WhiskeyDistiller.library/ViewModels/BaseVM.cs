using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class BaseVM : INotifyPropertyChanged
    {
        protected INavigation _navigation;

        public BaseVM(INavigation navigation)
        {
            _navigation = navigation;
        }

        public async Task NavigateToAsync<T>() where T : ContentPage => await _navigation.PushModalAsync((T)Activator.CreateInstance(typeof(T)));

        public ICommand GoBackCommand => new Command(async () => { await _navigation.PopModalAsync(); });

        public Command NavigateCommand<T>() where T : ContentPage => 
            new Command(async () => { await NavigateToAsync<T>(); });

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}