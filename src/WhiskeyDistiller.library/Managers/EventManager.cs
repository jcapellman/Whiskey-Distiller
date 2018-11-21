using System;
using System.Collections.Generic;
using System.Linq;

using WhiskeyDistiller.library.Common;
using WhiskeyDistiller.library.DAL.Tables;

namespace WhiskeyDistiller.library.Managers
{
    public class EventManager : BaseManager
    {
        public ReturnSet<bool> AddEvent(string description, int gameId, string date)
        {
            var eventRow = new Event
            {
                Date = date,
                Description = description,
                GameID = gameId,
                Read = false
            };

            return IoC.DatabaseManager.Add(eventRow);
        }

        public ReturnSet<List<Event>> GetEvents(int gameId)
        {
            try
            {
                var events = IoC.DatabaseManager.Select<Event>(a => a.GameID == gameId && !a.Read);

                if (events.HasError)
                {
                    throw events.Error;
                }
                
                return new ReturnSet<List<Event>>(events.Object.OrderByDescending(a => a.Date).ToList());
            }
            catch (Exception ex)
            {
                return new ReturnSet<List<Event>>(ex, $"{gameId}");
            }
        }
    }
}