using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _1294372_Master_Details.Models.Entity
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Service Name is required")]
        [Display(Name = "Service Name")]
        [StringLength(30, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string ServiceName { get; set; } = default!;
        public virtual ICollection<ServiceEntry> ServiceEntries { get; set; } = new List<ServiceEntry>();
    }
}