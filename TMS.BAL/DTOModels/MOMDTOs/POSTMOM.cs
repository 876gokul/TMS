namespace TMS.BAL
{
    public class POSTMOM
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int StatusId { get; set; }
        public int OwnerId { get; set; }
        public string Agenda { get; set; }
        public string MeetingNotes { get; set; }
        public string PurposeOfMeeting { get; set; }
    }
}