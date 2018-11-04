using System.Collections.Generic;
using System.Linq;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;

namespace WhiskeyDistiller.library.Managers
{
    public class EventManager : BaseManager
    {
        public void AddEvent(string description, int gameID, string date)
        {
            var eventRow = new Event
            {
                Date = date,
                Description = description,
                GameID = gameID,
                Read = false
            };

            IoC.DatabaseManager.Add(eventRow);
        }

        public List<Event> GetEvents(int gameID)
        {
            var events = IoC.DatabaseManager.Select<Event>(a => a.GameID == gameID && !a.Read).OrderByDescending(a => a.Date).ToList();

            return events;
        }
    }
}
