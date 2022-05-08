using TMS.DAL;

namespace TMS.BAL
{
    public class GETMOM
    {
        public int Id { get; set; }
        public string Agenda { get; set; }
        public string MeetingNotes { get; set; }
        public string PurposeOfMeeting { get; set; }
        public virtual Review Review { get; set; }
        public virtual MOMStatus Status { get; set; }
        public virtual User Owner { get; set; }
    }
}