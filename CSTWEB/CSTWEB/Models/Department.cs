using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CST_Web.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pleasse Enter Name")]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
