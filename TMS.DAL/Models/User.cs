using System.Text.Json;
using System.Text.Json.Serialization;
namespace TMS.DAL
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int? DepartmentId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public string EmployeeId { get; set; }
        public bool isDisabled { get; set; }

        public virtual Role? Role { get; set; }
        public virtual Department? Department { get; set; }
        public virtual List<Course>? Courses { get; set; }
        [JsonIgnore]
        public DateTime? CreatedOn { get; set; }
        [JsonIgnore]
        public int? CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
        [JsonIgnore]
        public int? UpdatedBy { get; set; }
    }
}
