using EventsApp.Common.Contracts.Services;
using EventsApp.Common.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsApp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _evetService;

        public EventController(IEventService evetService)
        {
            _evetService = evetService;
        }

        [HttpPost]
        public IActionResult Create(EventDTO eventData)
        {
            var result = _evetService.CreateEvent(eventData);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _evetService.GetAll();
            return Ok(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _evetService.GetById(id);
            return Ok(result);
        }

        [HttpDelete("deleteById")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                return Ok(await _evetService.DeleteById(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPatch("updateEvent")]
        public async Task<IActionResult> UpdateEventById(int id, EventDTO eventData) 
        {
            try 
            {
                return Ok(await _evetService.UpdateEventById(id, eventData));
            }catch (Exception ex) { 
                return Problem(ex.Message);
            }
        }

    }
}