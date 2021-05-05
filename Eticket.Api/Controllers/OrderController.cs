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
    public class OrderController : ControllerBase
    {
        private OrderRepository OrderRepository { get; }

        public OrderController(OrderRepository orderRepository)
        {
            OrderRepository = orderRepository;
        }
        
        [HttpGet]
        [Authorize("admin")]
        public IActionResult GetAll()
        {
            return Ok(OrderRepository.GetAll());
        }
        
        [HttpGet("{Id}")]
        [Authorize("user")]
        public IActionResult Get(int id)
        {
            
            Orders order = OrderRepository.Get(id);
            if (order == null)  
                return NotFound();
            

            return Ok(order);
        }
        
        [HttpPost]
        [Authorize("user")]
        public IActionResult BuyTicket(OrderDto orderDto)
        {
            if (orderDto is null || !ModelState.IsValid)
                return BadRequest();
            
            
            ClaimsPrincipal cp = HttpContext.User;
            string idUser = cp.Claims.SingleOrDefault(c => c.Type == "UserId")?.Value;

            int idParse = int.Parse(idUser);

            if (idParse != orderDto.UserId)
                return BadRequest();


            int id = OrderRepository.Insert(new Orders()
            {
                TicketId = orderDto.TicketId,
                UserId = orderDto.UserId,
                Quantity = orderDto.Quantity
            });

            return Ok(id);
        }
        
    }
}