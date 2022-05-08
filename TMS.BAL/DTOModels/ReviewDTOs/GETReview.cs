using TMS.DAL;
namespace TMS.BAL
{
    public class GETReview
    {
        public int Id { get; set; }
        public string ReviewDate { get; set; }
        public string ReviewTime { get; set; }
        public string Mode { get; set; }
        public bool isDisabled { get; set; }
        public User Reviewer { get; set; }
        public User Trainee { get; set; }
        public ReviewStatus Status { get; set; }
    }
}