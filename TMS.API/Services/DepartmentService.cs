using Microsoft.EntityFrameworkCore;
using TMS.API.UtilityFunctions;
using TMS.BAL;
using TMS.DAL;
namespace TMS.API.Services
{
    public class DepartmentService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<DepartmentService> _logger;
        private void logErrorMessageContextError(InvalidOperationException ex)
        {
            _logger.LogCritical("An Critical error occured in User services. Please check the program.cs, context class and connection string. It happend due to failure of Dbcontext injection");
            _logger.LogTrace(ex.ToString());
        }
        private void logGeneralErrorMessage(Exception ex)
        {
            _logger.LogCritical("An Critical error occured in User services. Some external factors are involved. please check the log files to know more about it");
            _logger.LogTrace(ex.ToString());
        }
        public DepartmentService(AppDbContext context, ILogger<DepartmentService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Department GetUserById(int id)
        {
            if (id == 0) throw new ArgumentException("GetUserById requires a vaild Id not zero");
            try
            {
                var db = _context.Departments.Find(id);
                if (db != null)
                {
                    return db;
                }
                return null;
            }
            catch (System.InvalidOperationException ex)
            {
                logErrorMessageContextError(ex);
                throw ex;
            }
            catch (System.Exception ex)
            {
                logGeneralErrorMessage(ex);
                throw ex;
            }
        }
        public bool CreateUser(Department data)
        {
            if (data == null) throw new ArgumentException("CreateUser requires a vaild User Object");
            try
            {
                var dbData = new Department();
                dbData.Name = data.Name;
                _context.Departments.Add(dbData);
                _context.SaveChanges();
                return true;
            }
            catch (System.InvalidOperationException ex)
            {
                logErrorMessageContextError(ex);
                throw ex;
            }
            catch (System.Exception ex)
            {
                logGeneralErrorMessage(ex);
                throw ex;
            }

        }


    }
}

