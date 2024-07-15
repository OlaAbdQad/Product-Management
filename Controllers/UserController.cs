using Assessment_Task.Auth;
using Assessment_Task.Dtos;
using Assessment_Task.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SMS_web_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtManager _jwtManager;
        private readonly IBlacklistedTokenService _blacklist;

        public UserController(IUserService userService, IJwtManager jwtManager, IBlacklistedTokenService blacklist)
        {
            _userService = userService;
            _jwtManager = jwtManager;
            _blacklist = blacklist;
        }
        [Authorize(Roles = "Super-Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequestModel request)
        {
            await _userService.AddAsync(request);
            return Ok();
        }
        [Authorize(Roles = "Super-Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll(Guid id)
        {
            return Ok(await _userService.GetAllAsync());
        }
        [HttpPost("login")]
        public async Task<IActionResult> Token([FromBody] LoginRequestModel request)
        {
            var user  = await _userService.LoginAsync(request);
            if(user == null) return NotFound();
            var tokenResponse =  _jwtManager.GenerateToken(user);
            return Ok(tokenResponse);
        }
        [AllowAnonymous]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            await _blacklist.AddAsync(token);
            return Ok(new { message = "Logged out successfully" });
        }
        
    }
}