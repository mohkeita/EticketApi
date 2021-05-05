using Eticket.Api.Models.Dto;
using Eticket.Dal.Entities;
using Eticket.Dal.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private AddressRepository AddressRepository { get; }

        public AddressController(AddressRepository addressRepository)
        {
            AddressRepository = addressRepository;
        }
        
        [HttpGet]
        [Authorize("admin")]
        public IActionResult GetAll()
        {
            return Ok(AddressRepository.GetAll());
        }
        
        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            
            Address address = AddressRepository.Get(id);
            if (address == null)  
                return NotFound();
            

            return Ok(address);
        }
        
        [HttpPost]
        [Authorize("admin")]
        public IActionResult AddAddress(AddressDto addressDto)
        {
            if (addressDto is null || !ModelState.IsValid)
                return BadRequest();
            
            
            int id = AddressRepository.Insert(new Address()
            {
                Street = addressDto.Street,
                City = addressDto.City
            });

            return Ok(id);
        }
        
        [HttpPut]
        [Authorize("admin")]
        public IActionResult EditAddress(Address address)
        {
            Address existAddress = AddressRepository.Get(address.Id);
            if (existAddress == null)
                return NotFound();

            bool addressUpdate = AddressRepository.Update(address);

            return Ok(addressUpdate);
        }
        
        [HttpDelete("{Id}")]
        [Authorize("admin")]
        public IActionResult DeleteAddress(int id)
        {
            Address existAddress = AddressRepository.Get(id);
            if (existAddress == null)
                return NotFound();

            bool addressDelete = AddressRepository.Delete(id);

            return Ok(addressDelete);
        }
        
    }
}