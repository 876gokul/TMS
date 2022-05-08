using TMS.DAL;
namespace TMS.BAL
{
    public class GETAssigment
    {
        public int Id { get; set; }
        public byte[] Document { get; set; }
        public virtual AssignmentStatus Status { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual User Owner { get; set; }
    }
}