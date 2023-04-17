using EventsApp.Common.Contracts.Repositories;
using EventsApp.Common.Contracts.Services;
using EventsApp.Common.DTOs;

namespace EventApp.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public bool CreateEvent(EventDTO eventData)
        {
            var result = _eventRepository.CreateEvent(eventData);
            return result;
        }

        public List<EventDTO> GetAll() {
            var result = _eventRepository.GetAll();
            return result;
        }
        public EventDTO GetById(int id) {
            var result = _eventRepository.GetById(id);
            return result;
        }

       public async Task<bool> DeleteById(int id)
        {
            return await _eventRepository.DeleteById(id);
        }

        public async Task<bool> UpdateEventById(int id, EventDTO eventData) {
            return await _eventRepository.UpdateEventById(id, eventData);
        }

    }
}
