using System.ComponentModel.DataAnnotations;

namespace CST_Web.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string EquipmentCode { get; set; }
        public string Manufacturer { get; set; }
        public string Agent { get; set; }
        public string Cost { get; set; }
        public DateTime createdtime { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public Category? Categories { get; set; }
        public int EquipmentFamilyId { get; set; }
        public EquipmentFamily? EquipmentsFamily { get; set; }
        public int EqclassId { get; set; }
        public Eqclass? Eqclasses { get; set; }
        public DateTime installedtime { get; set; }
        public int DepartmentId { get; set; }
        public Department? Departments { get; set; }
        public int LocationId { get; set; }
        public Location? Locations { get; set; }
        public string Note { get; set; }


    }
}
