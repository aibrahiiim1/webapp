using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CST_Web.Models
{
    public class Classification
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pleasse Enter Name")]
        [MaxLength(25)]
        public string Name { get; set; }
        [AllowNull]
        public string? Description { get; set; }
        public DateTime createdtime { get; set; } = DateTime.Now;
    }
}
