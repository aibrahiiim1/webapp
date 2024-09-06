using System.ComponentModel.DataAnnotations;

namespace CST_Web.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department? Departments { get; set; }
    }
}
