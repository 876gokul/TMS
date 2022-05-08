using System.Text.Json;
using System.Text.Json.Serialization;
namespace TMS.DAL
{
    public class CourseFeedback
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int OwnerId { get; set; }
        public string Feedback { get; set; }
        public float Rating { get; set; }

        public virtual Course? Course { get; set; }
        public virtual User? Owner { get; set; }
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