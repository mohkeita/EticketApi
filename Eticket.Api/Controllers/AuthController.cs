using Eticket.Api.Models.Dto;
using Eticket.Api.TokenJWT;
using Eticket.Dal.Entities;
using Eticket.Dal.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eticket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserAppRepository UserAppRepository { get; }
        private TokenManager TokenManager { get; }

        public AuthController(UserAppRepository userAppRepository, TokenManager tokenManager)
        {
            UserAppRepository = userAppRepository;
            TokenManager = tokenManager;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserRegister userRegister)
        {
            if (userRegister is null || !ModelState.IsValid)
                return BadRequest();
            
            
            int id = UserAppRepository.Insert(new UserApp()
            {
                Username = userRegister.Username,
                Email = userRegister.Email,
                Firstname = userRegister.Firstname,
                Lastname = userRegister.Lastname,
                DateBirth = userRegister.DateBirth,
                Password = userRegister.Password
            });

            return Ok(id);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserLogin userLogin)
        {
            if (userLogin is null || !ModelState.IsValid)
                return BadRequest();

            UserApp userApp = UserAppRepository.Login(userLogin.Email, userLogin.Password);
            
            if (userApp is null)
                return new ForbidResult();
            

            if (userApp.Blocked)
                return new ForbidResult();
            
            
            string fullName = userApp.Firstname + ' ' + userApp.Lastname;
            return Ok(new UserWithToken()
            {
                Id = userApp.Id,
                FullLastname = fullName,
                Role = userApp.IsAdmin,
                Token = TokenManager.GenerateJWT(userApp)
            });

        }
        
    }
}