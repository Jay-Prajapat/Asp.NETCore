using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Practical_19.Interfaces;
using Practical_19.Models;

namespace Practical_19.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        string registerMessage = "Registration completed successfully!!";
        string loginMessage = "Login completed successfully!!";
        string invalidDetails = "User details are invalid";
        string notFoundError = "User not found";
        private readonly IAuthentication authentication;
        public AuthApiController(IAuthentication authentication)
        {
            this.authentication = authentication;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await authentication.RegisterAsync(model);

                    if (result.Succeeded)
                    {
                        return StatusCode(200, registerMessage);
                    }

                    foreach (IdentityError error in result.Errors)
                    {
                        return BadRequest(error.Description);
                        
                    }
                }
                return BadRequest(invalidDetails);
               
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await authentication.LoginAsync(model);

                    if (result != null)
                    {
                        return StatusCode(200, loginMessage);
                    }
                    return NotFound(notFoundError);

                }
                return BadRequest(invalidDetails);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
