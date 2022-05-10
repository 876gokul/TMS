using Microsoft.EntityFrameworkCore;
using TMS.API.UtilityFunctions;
using TMS.BAL;
using TMS.DAL;
namespace TMS.API.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UserService> _logger;
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
        public UserService(AppDbContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<User> GetUsersByRole(int roleId)
        {
            if (roleId == 0) throw new ArgumentException("GetUsersByRole requires a vaild Id not zero");
            try
            {
                return _context.Users.Where(u => u.RoleId == roleId).Include("Role").Include("Department").ToList();
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
        public IEnumerable<User> GetUsersByDepartment(int departmentId)
        {
            if (departmentId == 0) throw new ArgumentException("GetUsersByDepartment requires a vaild Id not zero");
            try
            {
                return _context.Users.Where(u => (u.DepartmentId != 0 && u.DepartmentId == departmentId)).ToList();
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
        public User GetUserById(int id)
        {
            if (id == 0) throw new ArgumentException("GetUserById requires a vaild Id not zero");
            try
            {
                var dbUser = _context.Users.Find(id);
                if (dbUser != null)
                {
                    User result = new User();
                    string base64String = Convert.ToBase64String(dbUser.Image, 0, dbUser.Image.Length);
                    if (dbUser.DepartmentId != null)
                    {
                        result = _context.Users.Where(u => u.Id == id).Include("Role").Include("Department").FirstOrDefault();
                        result.profilePic = "data:image/jpeg;base64," + base64String;
                        result.Password = string.Empty;
                    }
                    else
                    {
                        result = _context.Users.Where(u => u.Id == id).Include("Role").FirstOrDefault();
                        result.Password = string.Empty;
                    }
                    return result;
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
        public bool CreateUser(User user)
        {
            if (user == null) throw new ArgumentException("CreateUser requires a vaild User Object");
            try
            {
                Random ran = new Random();
                user.Password = HashPassword.Sha256(user.Password);
                user.Image = System.Convert.FromBase64String(user.profilePic);
                user.EmployeeId = ($"ACE{user.RoleId}{ran.Next(0, 10000)}");
                user.isDisabled = false;
                user.CreatedOn = DateTime.Now;

                _context.Users.Add(user);
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

        public bool UpdateUser(POSTUserDTO user)
        {
            if (user == null) throw new ArgumentException("UpdateUser requires a vaild User Object");
            try
            {
                var dbUser = _context.Users.Find(user.Id);
                if (dbUser != null)
                {
                    dbUser.RoleId = user.RoleId;
                    if (user.DepartmentId != 0) dbUser.DepartmentId = user.DepartmentId;
                    dbUser.Name = user.Name;
                    dbUser.UserName = user.UserName;
                    dbUser.Password = HashPassword.Sha256(user.Password);
                    dbUser.Email = user.Email;
                    dbUser.UpdatedOn = DateTime.Now;
                    dbUser.Image = System.Convert.FromBase64String(user.Image);

                    _context.Update(dbUser);
                    _context.SaveChanges();
                    return true;
                }
                return false;
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



        public bool DisableUser(int userId)
        {
            if (userId == 0) throw new ArgumentException("DisableUser requires a vaild User Id");
            try
            {
                var dbUser = _context.Users.Find(userId);
                if (dbUser != null)
                {
                    dbUser.isDisabled = true;
                    dbUser.UpdatedOn = DateTime.Now;
                    _context.Update(dbUser);
                    _context.SaveChanges();
                    return true;
                }
                return false;
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

