using Microsoft.AspNetCore.Mvc;
using TMS.API.Services;
using TMS.BAL;
namespace TMS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;
        private void logServiceInjectionFailed(InvalidOperationException ex)
        {
            _logger.LogCritical("An Critical error occured in User Controller. Please check the program.cs. It happend due to failure of userService injection");
            _logger.LogTrace(ex.ToString());
        }
        private void logCheckUserServiceErrorMessage(Exception ex, string actionMethod)
        {
            _logger.LogWarning($"There was an error in {actionMethod}. please check the user service for more information");
            _logger.LogError($"error thrown by user service " + ex.ToString());
        }
        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpGet("Role/{id:int}")]
        public IActionResult GetAllUserByRole(int id)
        {
            if (id == 0) return BadRequest("Please provide a valid role id");
            try
            {
                var result = _userService.GetUsersByRole(id);
                if (result.Count() > 0) return Ok(result);
                return NotFound("we are sorry, the thing you requested was not found");
            }
            catch (System.InvalidOperationException ex)
            {
                logServiceInjectionFailed(ex);
            }
            catch (System.Exception ex)
            {
                logCheckUserServiceErrorMessage(ex, nameof(GetAllUserByRole));
            }
            return Problem("we are sorry, some thing went wrong");
        }

        [HttpGet("Department/{id:int}")]
        public IActionResult GetAllUserByDepartment(int id)
        {
            if (id == 0) return BadRequest("Please provide a valid Depatment id");
            try
            {
                var result = _userService.GetUsersByDepartment(id);
                if (result.Count() > 0) return Ok(result);
                return NotFound("we are sorry, the thing you requested was not found");
            }
            catch (System.InvalidOperationException ex)
            {
                logServiceInjectionFailed(ex);
            }
            catch (System.Exception ex)
            {
                logCheckUserServiceErrorMessage(ex, nameof(GetAllUserByDepartment));
            }
            return Problem("we are sorry, some thing went wrong");
        }

        [HttpGet("/{id:int}")]
        public IActionResult GetUserById(int id)
        {
            if (id == 0) return BadRequest("Please provide a valid User id");
            try
            {
                var result = _userService.GetUserById(id);
                if (result != null) return Ok(result);
                return NotFound("User was Not Found");
            }
            catch (System.InvalidOperationException ex)
            {
                logServiceInjectionFailed(ex);
            }
            catch (System.Exception ex)
            {
                logCheckUserServiceErrorMessage(ex, nameof(GetUserById));
            }
            return Problem("we are sorry, some thing went wrong");
        }

        [HttpPost]
        public IActionResult CreateUser(POSTUserDTO user)
        {
            if (user == null) return BadRequest("User is required");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            {
                try
                {
                    var res = _userService.CreateUser(user);
                    if (res) return Ok("The User was Created successfully");
                }
                catch (System.InvalidOperationException ex)
                {
                    logServiceInjectionFailed(ex);
                }
                catch (System.Exception ex)
                {
                    logCheckUserServiceErrorMessage(ex, nameof(CreateUser));
                }
                return Problem("we are sorry, some thing went wrong");
            }
        }

        [HttpPut]
        public IActionResult UpdateUser(POSTUserDTO user)
        {
            if (user == null) return BadRequest("User is required");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var res = _userService.UpdateUser(user);
                if (res) return Ok("The User was Updated successfully");
                return NotFound("we are sorry, the thing you requested was not found");

            }
            catch (System.InvalidOperationException ex)
            {
                logServiceInjectionFailed(ex);
            }
            catch (System.Exception ex)
            {
                logCheckUserServiceErrorMessage(ex, nameof(UpdateUser));
            }
            return Problem("we are sorry, some thing went wrong");

        }

        [HttpDelete("Disable/{id:int}")]
        public IActionResult DisableUser(int id)
        {
            if (id == 0) return BadRequest("User is required");
            try
            {
                var res = _userService.DisableUser(id);
                if (res) return Ok("The User was Disabled successfully");
                return NotFound("we are sorry, the thing you requested was not found");
            }
            catch (System.InvalidOperationException ex)
            {
                logServiceInjectionFailed(ex);
            }
            catch (System.Exception ex)
            {
                logCheckUserServiceErrorMessage(ex, nameof(DisableUser));
            }
            return Problem("we are sorry, some thing went wrong");

        }
    }
}