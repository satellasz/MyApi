using MyApi.Domain.Models;
using MyApi.Domain.Services;
using MyApi.Domain.Models.DTOs;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MyApi.Controllers
{
    [Authorize]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _service;

        public AuthController(AuthService service)
        {
            _service = service;
        }

        // POST: api/Auth/SignUp
        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUp([FromBody] SignUpDTO signUpDto)
        {
            if (signUpDto == null)
            {
                return BadRequest();
            }

            bool ret = await _service.SignUp(signUpDto);

            try
            {
                return Ok(ret);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        // POST: api/Auth/SignIn
        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<ActionResult> SignIn([FromBody] SignInDTO signInDto)
        {
            if (signInDto == null)
            {
                return BadRequest();
            }

            SsoDTO user = await _service.SignIn(signInDto);

            try
            {
                return Ok(user);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        // GET: api/Auth/GetCurrentUser
        [HttpGet("current-user")]
        public async Task<ActionResult> GetCurrentUser()
        {
            var user = await _service.GetCurrentUser();

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(user);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }     
    }
}
