using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public interface IEventRepository:IRepository<Event>
    {
        public IEnumerable<EventThematic> Thematics();
        public IEnumerable<EventType> Types();
        public IEnumerable<EventOrganizer> Organizers();
        public IEnumerable<EventPersonality> Personalities();
        public EventThematic Theme(int themeId);
        public EventType Type(int typeId);

    }
}
