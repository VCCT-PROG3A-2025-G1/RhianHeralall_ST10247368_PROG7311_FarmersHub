using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmersHub.Models
{
    public class Farmer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Product> Products { get; set; }
    }

}
