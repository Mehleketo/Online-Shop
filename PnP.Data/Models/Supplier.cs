using System.Collections.Generic;

namespace PnP.Data.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string HomePage { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
