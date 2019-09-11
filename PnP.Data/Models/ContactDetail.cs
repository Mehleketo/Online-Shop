namespace PnP.Data.Models
{
    public class ContactDetail
    {
        public int Id { get; set; }
        public string CellNumber { get; set; }
        public string WorkNumber { get; set; }
        public string HomeNumber { get; set; }
        public string DateCreated { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
