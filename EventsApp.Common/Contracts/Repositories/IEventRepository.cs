using EventsApp.Common.DTOs;

namespace EventsApp.Common.Contracts.Repositories
{
    public interface IEventRepository
    {
        bool CreateEvent(EventDTO eventData);
        List<EventDTO> GetAll();
        EventDTO GetById(int id);
        Task<bool> DeleteById(int id);
        Task<bool> UpdateEventById(int id, EventDTO eventData);
    }
}
