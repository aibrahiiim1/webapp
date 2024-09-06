using CST_Web.Models;

namespace CSTWEB.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public Department? Departments { get; set; }
    }
}
