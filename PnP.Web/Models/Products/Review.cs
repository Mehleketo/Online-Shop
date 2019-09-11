using System;

namespace PnP.Web.Models.Products
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
        public string UserFullName { get; set; }
    }
}
