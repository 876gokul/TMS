using TMS.DAL;

namespace TMS.BAL
{
    public class GETUserDTO
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int? DepartmentId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string EmployeeId { get; set; }
        public bool isDisabled { get; set; }

        public virtual Role Role { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
