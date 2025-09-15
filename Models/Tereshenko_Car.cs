using System.ComponentModel.DataAnnotations;

namespace Tereshenko_crossplatform1.Models
{
    public class Tereshenko_Car
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Make { get; set; } = "";

        [Required, StringLength(100)]
        public string Model { get; set; } = "";

        [Range(1900, 2100)]
        public int Year { get; set; }

        [Range(0, 100000000)]
        public decimal Price { get; set; }
    }
}
