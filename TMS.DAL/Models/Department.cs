using System.Text.Json;
using System.Text.Json.Serialization;
namespace TMS.DAL
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isDisabled { get; set; }
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