using EventsApp.AccessData.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsApp.AccessData
{
    public class EventsAppContext : DbContext
    {
        public EventsAppContext(DbContextOptions<EventsAppContext> options)
            : base(options) { }

        public DbSet<Event> Events { get; set; }
    }
}
