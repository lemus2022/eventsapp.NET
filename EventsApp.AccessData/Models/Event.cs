

using EventsApp.Common.DTOs;

namespace EventsApp.AccessData.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public EventDTO ToDTO()
        {
            return new EventDTO { Id = Id, Name = Name, Description = Description };
        }
    }
}
