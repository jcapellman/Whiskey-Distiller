using System.Collections.Generic;

using WhiskeyDistiller.library.DAL.Tables;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class BatchPageVm : BaseVm
    {
        private List<Release> _currentReleases;

        public List<Release> CurrentReleases
        {
            get => _currentReleases;
            set { _currentReleases = value; OnPropertyChanged(nameof(CurrentReleases)); }
        }

        public BatchPageVm(INavigation navigation) : base(navigation)
        {
        }
    }
}