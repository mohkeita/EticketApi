using Eticket.Dal.Entities;
using Eticket.Dal.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserAppRepository UserAppRepository { get; }
        
        public UserController(UserAppRepository userAppRepository)
        {
            UserAppRepository = userAppRepository;
        }
        
        [HttpGet]
        [Authorize("admin")]
        public IActionResult GetAll()
        {
            return Ok(UserAppRepository.GetAll());
        }
        
        [HttpGet("{Id}")]
        [Authorize("admin")]
        public IActionResult GetUser(int id)
        {
            
            UserApp user = UserAppRepository.Get(id);
            if (user == null)  
                return NotFound();
            

            return Ok(user);
        }
        
        [HttpPut("blockunblock/{Id}")]
        [Authorize("admin")]
        public IActionResult BlockUnblock(int id, UserApp user)
        {
            if (user.Id != id)
                return BadRequest();
            
            
            if (UserAppRepository.Get(id) == null)
                return NotFound();
            
            
            return Ok(UserAppRepository.BlockUnBlockUser(user));
        }
        
    }
}