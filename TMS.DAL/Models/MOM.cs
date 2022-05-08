using System.Text.Json;
using System.Text.Json.Serialization;
namespace TMS.DAL
{
    public class MOM
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int StatusId { get; set; }
        public int OwnerId { get; set; }
        public string Agenda { get; set; }
        public string MeetingNotes { get; set; }
        public string PurposeOfMeeting { get; set; }

        public virtual Review Review { get; set; }
        public virtual MOMStatus? Status { get; set; }
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