using TMS.DAL;

namespace TMS.BAL
{
    public class GETTopic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Context { get; set; }
        public bool isDisabled { get; set; }
        public Course Course { get; set; }

    }
}