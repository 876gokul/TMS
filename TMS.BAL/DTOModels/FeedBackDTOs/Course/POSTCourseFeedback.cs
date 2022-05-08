namespace TMS.BAL
{
    public class POSTCourseFeedback
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int OwnerId { get; set; }
        public string Feedback { get; set; }
        public float Rating { get; set; }
    }
}