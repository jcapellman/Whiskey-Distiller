using System.Collections.Generic;

using WhiskeyDistiller.library.DAL.Tables;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class BatchPageVM : BaseVM
    {
        private List<Release> _currentReleases;

        public List<Release> CurrentReleases
        {
            get { return _currentReleases; }
            set { _currentReleases = value; OnPropertyChanged("CurrentReleases"); }
        }

        public BatchPageVM(INavigation navigation) : base(navigation)
        {
        }
    }
}