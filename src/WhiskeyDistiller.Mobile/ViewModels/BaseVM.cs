using System.ComponentModel;

namespace WhiskeyDistiller.Mobile.ViewModels
{
    public class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}