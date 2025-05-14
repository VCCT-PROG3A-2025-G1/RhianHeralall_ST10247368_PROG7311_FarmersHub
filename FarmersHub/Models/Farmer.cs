using System.Collections.Generic;

namespace FarmersHub.Models
{
    public class Farmer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
