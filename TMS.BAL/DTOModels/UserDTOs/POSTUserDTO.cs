namespace TMS.BAL
{
    public class POSTUserDTO
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}
