using TMS.DAL;

namespace TMS.BAL
{
    public class GETCourseFeedback
    {
        public int Id { get; set; }
        public string Feedback { get; set; }
        public float Rating { get; set; }
        public virtual Course Course { get; set; }
        public virtual User Owner { get; set; }
    }
}