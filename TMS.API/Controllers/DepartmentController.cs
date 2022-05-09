// using Microsoft.AspNetCore.Mvc;
// using TMS.API.Services;
// using TMS.BAL;
// using TMS.DAL;

// namespace TMS.API.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class DepartmentController : ControllerBase
//     {
//         private readonly ILogger<DepartmentController> _logger;
//         private readonly UserService _userService;
//         private void logServiceInjectionFailed(InvalidOperationException ex)
//         {
//             _logger.LogCritical("An Critical error occured in User Controller. Please check the program.cs. It happend due to failure of userService injection");
//             _logger.LogTrace(ex.ToString());
//         }
//         private void logCheckUserServiceErrorMessage(Exception ex, string actionMethod)
//         {
//             _logger.LogWarning($"There was an error in {actionMethod}. please check the user service for more information");
//             _logger.LogError($"error thrown by user service " + ex.ToString());
//         }
//         public DepartmentController(ILogger<DepartmentController> logger, DepartmentService userService)
//         {
//             _logger = logger;
//             _userService = userService;
//         }
//         [HttpGet("Role/{id:int}")]


//         [HttpGet("/{id:int}")]
//         public IActionResult GetUserById(int id)
//         {
//             if (id == 0) return BadRequest("Please provide a valid User id");
//             try
//             {
//                 var result = _userService.GetUserById(id);
//                 if (result != null) return Ok(result);
//                 return NotFound("User was Not Found");
//             }
//             catch (System.InvalidOperationException ex)
//             {
//                 logServiceInjectionFailed(ex);
//             }
//             catch (System.Exception ex)
//             {
//                 logCheckUserServiceErrorMessage(ex, nameof(GetUserById));
//             }
//             return Problem("we are sorry, some thing went wrong");
//         }

//         [HttpPost]
//         public IActionResult CreateUser([FromForm] Department data)
//         {
//             if (DataMisalignedException == null) return BadRequest("User is required");
//             if (!ModelState.IsValid) return BadRequest(ModelState);
//             {
//                 try
//                 {
//                     var res = _userService.CreateUser(data);
//                     if (res) return Ok("The User was Created successfully");
//                 }
//                 catch (System.InvalidOperationException ex)
//                 {
//                     logServiceInjectionFailed(ex);
//                 }
//                 catch (System.Exception ex)
//                 {
//                     logCheckUserServiceErrorMessage(ex, nameof(CreateUser));
//                 }
//                 return Problem("we are sorry, some thing went wrong");
//             }
//         }

//     }    
// }