using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Eticket.Api.Models.Dto;
using Eticket.Dal.Entities;
using Eticket.Dal.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private EventRepository EventRepository { get; }
        private AddressRepository AddressRepository { get; }
        private TicketRepository TicketRepository { get; }

        public EventController(EventRepository eventRepository, AddressRepository addressRepository, 
            TicketRepository ticketRepository)
        {
            EventRepository = eventRepository;
            AddressRepository = addressRepository;
            TicketRepository = ticketRepository;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(EventRepository.GetAllUser());
        }
        
        [HttpGet("admin")]
        [Authorize("admin")]
        public IActionResult GetAllAdmin()
        {
            
            return Ok(EventRepository.GetAll());
        }
        
        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            
            Event events = EventRepository.Get(id);
            if (events == null)  
                return NotFound();
            

            return Ok(events);
        }
        
        [HttpPost]
        [Authorize("admin")]
        public IActionResult AddEvent(EventDto eventDto)
        {
            if (eventDto is null || !ModelState.IsValid)
                return BadRequest();
            
            ClaimsPrincipal cp = HttpContext.User;
            string idUser = cp.Claims.SingleOrDefault(c => c.Type == "UserId")?.Value;

            int idParse = int.Parse(idUser);

            if (idParse != eventDto.UserId)
                return BadRequest();

            int idAddress;
            int idTicket;
            
            try
            {
                idAddress = AddressRepository.Insert(new Address()
                {
                    Street = eventDto.Street,
                    City = eventDto.City
                });
            
                idTicket = TicketRepository.Insert(new Tickets()
                {
                    Quantity = eventDto.Quantity,
                    UnitPrice = eventDto.UnitPrice
                });

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
            
            
            int id = EventRepository.Insert(new Event()
            {
                UserId = eventDto.UserId,
                OrganizersId = eventDto.OrganizersId,
                CategoryId = eventDto.CategoryId,
                Title = eventDto.Title,
                Description = eventDto.Description,
                DateEvent = eventDto.DateEvent,
                AddressId = idAddress,
                TicketId = idTicket
            });

            return Ok(id);
        }
        
        [HttpPut]
        [Authorize("admin")]
        public IActionResult EditEvent(Event events)
        {
            Event existEvents = EventRepository.Get(events.Id);
            if (existEvents == null)
                return NotFound();

            bool eventUpdate = EventRepository.Update(events);

            return Ok(eventUpdate);
        }
        
    }
}