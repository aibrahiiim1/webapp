using System.ComponentModel.DataAnnotations;

namespace CST_Web.Models
{
    public class EquipmentStatus
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pleasse Enter Status")]
        [MaxLength(25)]
        public string Name { get; set; }
        public DateTime createdtime { get; set; } = DateTime.Now;
    }
}
