using System.Collections.Generic;
using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class EventsPageVM : BaseVM
    {
        private List<Event> _events;

        public List<Event> Events
        {
            get { return _events; }
            set { _events = value; OnPropertyChanged("Events"); }
        }

        public EventsPageVM(INavigation navigation) : base(navigation)
        {
            Events = IoC.EventManager.GetEvents(IoC.GameManager.CurrentGame.ID);
        }
    }
}