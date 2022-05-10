using Microsoft.AspNetCore.Mvc;
using TMS.API.Services;
using TMS.API.UtilityFunctions;
using TMS.BAL;
using TMS.DAL;

namespace TMS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;
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
                TMSLogger.logServiceInjectionFailed(ex, _logger);
            }
            catch (System.Exception ex)
            {
                TMSLogger.logCheckUserServiceErrorMessage(ex, nameof(GetAllUserByRole), _logger);
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
                TMSLogger.logServiceInjectionFailed(ex, _logger);
            }
            catch (System.Exception ex)
            {
                TMSLogger.logCheckUserServiceErrorMessage(ex, nameof(GetAllUserByDepartment), _logger);
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
                TMSLogger.logServiceInjectionFailed(ex, _logger);
            }
            catch (System.Exception ex)
            {
                TMSLogger.logCheckUserServiceErrorMessage(ex, nameof(GetUserById), _logger);
            }
            return Problem("we are sorry, some thing went wrong");
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (user == null) return BadRequest("User is required");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var res = _userService.CreateUser(user);
                var Result = new
                {
                    message = "The user created successfully"
                };
                if (res) return Ok(Result);
            }
            catch (System.InvalidOperationException ex)
            {
                TMSLogger.logServiceInjectionFailed(ex, _logger);
            }
            catch (System.Exception ex)
            {
                TMSLogger.logCheckUserServiceErrorMessage(ex, nameof(CreateUser), _logger);
            }
            return Problem("we are sorry, some thing went wrong");

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
                TMSLogger.logServiceInjectionFailed(ex, _logger);
            }
            catch (System.Exception ex)
            {
                TMSLogger.logCheckUserServiceErrorMessage(ex, nameof(UpdateUser), _logger);
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
                TMSLogger.logServiceInjectionFailed(ex, _logger);
            }
            catch (System.Exception ex)
            {
                TMSLogger.logCheckUserServiceErrorMessage(ex, nameof(DisableUser), _logger);
            }
            return Problem("we are sorry, some thing went wrong");

        }
    }
}