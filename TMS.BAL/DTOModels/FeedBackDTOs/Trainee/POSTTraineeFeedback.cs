using TMS.DAL;

namespace TMS.BAL
{
    class POSTTraineeFeedback
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public int TrainerId { get; set; }
        public int CourseId { get; set; }
        public string Feedback { get; set; }
    }
}