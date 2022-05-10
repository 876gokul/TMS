using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;

namespace TMS.API.UtilityFunctions
{
    public static class TMSLogger
    {
        public static void logServiceInjectionFailed(InvalidOperationException ex, ILogger _logger)
        {
            _logger.LogCritical("An Critical error occured in User Controller. Please check the program.cs. It happend due to failure of userService injection");
            _logger.LogTrace(ex.ToString());
        }
        public static void logCheckUserServiceErrorMessage(Exception ex, string actionMethod, ILogger _logger)
        {
            _logger.LogWarning($"There was an error in {actionMethod}. please check the user service for more information");
            _logger.LogError($"error thrown by user service " + ex.ToString());
        }
    }
}