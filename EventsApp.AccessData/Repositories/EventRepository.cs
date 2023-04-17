using EventsApp.AccessData.Models;
using EventsApp.Common.Contracts.Repositories;
using EventsApp.Common.DTOs;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Xml.Linq;

namespace EventsApp.AccessData.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventsAppContext _context;

        public EventRepository(EventsAppContext context)
        {
            _context = context;
        }

        public bool CreateEvent(EventDTO eventData)
        {
            try
            {
                _context.Events.Add(new Event()
                {
                    Id = eventData.Id,
                    Name = eventData.Name,
                    Description = eventData.Description
                });
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<EventDTO> GetAll()
        {
            var eventsList = _context.Events;
            return eventsList.Select(el => el.ToDTO()).ToList();
        }

        public EventDTO GetById(int id)
        {
            List<EventDTO> events = GetAll();
            EventDTO eventById = events.FirstOrDefault(e => e.Id == id);
            return eventById ?? throw new ArgumentNullException(nameof(eventById));
        }

        public async Task<bool> DeleteById(int id) {
            
            var projectToDelete = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            
            if (projectToDelete != null)
            {
                _context.Events.Remove(projectToDelete);
                await _context.SaveChangesAsync();
                return true;

            }
            return false;

        }

        public async Task<bool> UpdateEventById(int id, EventDTO eventData) {

            var projectToUpdate = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (projectToUpdate != null)
            {
                //projectToUpdate.Id = eventData.Id;
                projectToUpdate.Name = eventData.Name;
                projectToUpdate.Description = eventData.Description;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

    }
}
