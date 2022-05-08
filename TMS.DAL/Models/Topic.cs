using System.Text.Json;
using System.Text.Json.Serialization;
namespace TMS.DAL
{
    public class Topic
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Context { get; set; }
        public bool isDisabled { get; set; }
        public Course? Course { get; set; }
        public List<Attendance>? Attendances { get; set; }
        public List<Assigment>? Assigments { get; set; }
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