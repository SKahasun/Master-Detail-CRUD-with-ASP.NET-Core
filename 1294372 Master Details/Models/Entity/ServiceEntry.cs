using System.ComponentModel.DataAnnotations;

namespace _1294372_Master_Details.Models.Entity
{
    public class ServiceEntry
    {
        public int ServiceEntryId { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "Service")]
        public int ServiceId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Service? Service { get; set; }
    }
}
