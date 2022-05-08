namespace TMS.BAL
{
    public class POSTReview
    {
        public int Id { get; set; }
        public int ReviewerId { get; set; }
        public int StatusId { get; set; }
        public int TraineeId { get; set; }
        public string ReviewDate { get; set; }
        public string ReviewTime { get; set; }
        public string Mode { get; set; }
    }
}