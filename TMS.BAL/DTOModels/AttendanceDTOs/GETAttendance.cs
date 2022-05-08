using TMS.DAL;
namespace TMS.BAL
{
    public class GETAttendance
    {
        public int Id { get; set; }
        public virtual AttendanceStatus Status { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual User Owner { get; set; }
    }
}