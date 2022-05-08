using TMS.DAL;
namespace TMS.BAL
{
    public class POSTAttendance
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int StatusId { get; set; }
        public int OwnerId { get; set; }
    }
}