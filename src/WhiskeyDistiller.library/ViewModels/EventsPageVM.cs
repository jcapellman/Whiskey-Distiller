﻿using System.Collections.Generic;
using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;

using Xamarin.Forms;

namespace WhiskeyDistiller.library.ViewModels
{
    public class EventsPageVm : BaseVm
    {
        private List<Event> _events;

        public List<Event> Events
        {
            get => _events;
            set { _events = value; OnPropertyChanged("Events"); }
        }

        public EventsPageVm(INavigation navigation) : base(navigation)
        {
            Events = IoC.EventManager.GetEvents(IoC.GameManager.CurrentGame.ID);
        }
    }
}