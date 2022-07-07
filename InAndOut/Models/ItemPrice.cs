using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Sdk;

namespace InAndOut.Models
{
    public class ItemPrice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage ="Amount message alertion!!!!")]
        public double Price { get; set; }
    }
}
