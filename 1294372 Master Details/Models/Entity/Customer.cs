using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace _1294372_Master_Details.Models.Entity
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Customer Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string CustomerName { get; set; } = default!;

        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(15)]
        public string Phone { get; set; } = default!;

        [Required(ErrorMessage = "Entry date is required")]
        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }

        [Required(ErrorMessage = "Device name is required")]
        [Display(Name = "Device Name")]
        [StringLength(30)]
        public string DeviceName { get; set; } = default!;

        [Required(ErrorMessage = "Please describe the device problem")]
        [Display(Name = "Problem Description")]
        [StringLength(200, ErrorMessage = "Description cannot exceed {1} characters")]
        public string Problem { get; set; } = default!;

        [Display(Name = "Device Picture")]
        public string? DevicePicture { get; set; }

        [Display(Name = "Buying Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BuyingDate { get; set; }

        [Display(Name = "Device Age (Years)")]
        [Range(0, 500, ErrorMessage = "{0} must be between {1} and {2}")]
        public int DeviceAge { get; set; }

        [Display(Name = "Is Regular Customer?")]
        public bool IsRegular { get; set; }

        [Display(Name = "Home Address")]
        [DataType(DataType.MultilineText)]
        [StringLength(255)]
        public string? Address { get; set; }

        public virtual ICollection<ServiceEntry> ServiceEntries { get; set; } = new List<ServiceEntry>();
    }
}