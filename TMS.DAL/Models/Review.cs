using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace TMS.DAL
{
    public class Review
    {
        public int Id { get; set; }
        public int ReviewerId { get; set; }
        public int StatusId { get; set; }
        public int TraineeId { get; set; }
        public string ReviewDate { get; set; }
        public string ReviewTime { get; set; }
        public string Mode { get; set; }
        public bool isDisabled { get; set; }
        public User? Reviewer { get; set; }
        public User? Trainee { get; set; }
        [NotMapped]
        public MOM? MOM { get; set; }
        public ReviewStatus? Status { get; set; }
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