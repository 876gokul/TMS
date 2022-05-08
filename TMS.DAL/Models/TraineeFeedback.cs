using System.Text.Json;
using System.Text.Json.Serialization;
namespace TMS.DAL
{
    public class TraineeFeedback
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public int TrainerId { get; set; }
        public int CourseId { get; set; }
        public string Feedback { get; set; }

        public virtual Course? Course { get; set; }
        public virtual User? Trainee { get; set; }
        public virtual User? Trainer { get; set; }
        [JsonIgnore]
        public DateTime? CreatedOn { get; set; }
        [JsonIgnore]
        public int? CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedOn { get; set; }
        [JsonIgnore]
        public int? UpdatedBy { get; set; }
    }
}