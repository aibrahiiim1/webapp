using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CST_Web.Models
{
    public class Hotel
    {   public int Id { get; set; }
        public string Name { get; set; }
        [AllowNull]
        public string? Description { get; set; }
        public DateTime createdtime { get; set; } = DateTime.Now;
    }
}
