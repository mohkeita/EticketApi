using Eticket.Api.Models.Dto;
using Eticket.Dal.Entities;
using Eticket.Dal.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizersController : ControllerBase
    {
        private OrganizersRepository OrganizersRepository { get; }

        public OrganizersController(OrganizersRepository organizersRepository)
        {
            OrganizersRepository = organizersRepository;
        }
        
        [HttpGet]
        [Authorize("admin")]
        public IActionResult GetAll()
        {
            return Ok(OrganizersRepository.GetAll());
        }
        
        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            
            Organizers organizers = OrganizersRepository.Get(id);
            if (organizers == null)  
                return NotFound();
            

            return Ok(organizers);
        }
        
        [HttpPost]
        [Authorize("admin")]
        public IActionResult AddOrganizer(OrganizersDto organizersDto)
        {
            if (organizersDto is null || !ModelState.IsValid)
                return BadRequest();
            
            
            int id = OrganizersRepository.Insert(new Organizers()
            {
                Name = organizersDto.Name,
                Email = organizersDto.Email,
                Phone = organizersDto.Phone,
                About = organizersDto.About
            });

            return Ok(id);
        }
        
        [HttpPut]
        [Authorize("admin")]
        public IActionResult EditOrganizer(Organizers organizers)
        {
            Organizers existOrganizers = OrganizersRepository.Get(organizers.Id);
            if (existOrganizers == null)
                return NotFound();

            bool organizerUpdate = OrganizersRepository.Update(organizers);

            return Ok(organizerUpdate);
        }
        
        [HttpDelete("{Id}")]
        [Authorize("admin")]
        public IActionResult DeleteOrganizer(int id)
        {
            Organizers existOrganizers = OrganizersRepository.Get(id);
            if (existOrganizers == null)
                return NotFound();

            bool organizerDelete = OrganizersRepository.Delete(id);

            return Ok(organizerDelete);
        }
        
    }
}