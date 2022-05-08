using TMS.DAL;

namespace TMS.BAL
{
    class GETTraineeFeedback
    {
        public int Id { get; set; }
        public string Feedback { get; set; }
        public virtual Course Course { get; set; }
        public virtual User Trainee { get; set; }
        public virtual User Trainer { get; set; }
    }
}