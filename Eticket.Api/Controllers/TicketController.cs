using Eticket.Api.Models.Dto;
using Eticket.Dal.Entities;
using Eticket.Dal.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private TicketRepository TicketRepository { get; }

        public TicketController(TicketRepository ticketRepository)
        {
            TicketRepository = ticketRepository;
        }
        
        [HttpGet]
        [Authorize("admin")]
        public IActionResult GetAll()
        {
            return Ok(TicketRepository.GetAll());
        }
        
        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            
            Tickets tickets = TicketRepository.Get(id);
            if (tickets == null)  
                return NotFound();
            

            return Ok(tickets);
        }
        
        [HttpPost]
        [Authorize("admin")]
        public IActionResult AddTicket(TicketDto ticketDto)
        {
            if (ticketDto is null || !ModelState.IsValid)
                return BadRequest();
            
            
            int id = TicketRepository.Insert(new Tickets()
            {
                Quantity = ticketDto.Quantity,
                UnitPrice = ticketDto.UnitPrice
            });

            return Ok(id);
        }
        
    }
}