using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class BaseVm : INotifyPropertyChanged
    {
        protected INavigation Navigation;

        public BaseVm(INavigation navigation)
        {
            Navigation = navigation;
        }

        public async Task NavigateToAsync<T>() where T : ContentPage => await Navigation.PushModalAsync((T)Activator.CreateInstance(typeof(T)));

        public ICommand GoBackCommand => new Command(async () => { await Navigation.PopModalAsync(); });

        public Command NavigateCommand<T>() where T : ContentPage => 
            new Command(async () => { await NavigateToAsync<T>(); });

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}