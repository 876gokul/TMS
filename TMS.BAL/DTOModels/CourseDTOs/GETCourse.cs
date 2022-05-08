using System.ComponentModel.DataAnnotations.Schema;
using TMS.DAL;
namespace TMS.BAL
{
    public class GETCourse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public virtual User Trainer { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<Topic> Topics { get; set; }
        public virtual List<User> Trainees { get; set; }
    }
}