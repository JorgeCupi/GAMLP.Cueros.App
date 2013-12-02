using System.Collections.Generic;
namespace Cueros.App.Core.Models
{
    public class Supplier
    {
        public string SupplierID { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        
        public string City { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public List<Material> Materials{ get; set; }
    }
}