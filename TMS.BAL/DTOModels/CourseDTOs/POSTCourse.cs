namespace TMS.BAL
{
    public class Course
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
    }
}