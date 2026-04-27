using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1294372_Master_Details.Models.ViewModels
{
    public class CustomerVM
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
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
        public DateTime EntryDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Device name is required")]
        [Display(Name = "Device Name")]
        [StringLength(30)]
        public string DeviceName { get; set; } = default!;

        [Required(ErrorMessage = "Please describe the problem")]
        [Display(Name = "Problem Description")]
        [StringLength(100)]
        public string Problem { get; set; } = default!;

        public string? DevicePicture { get; set; }

        [Display(Name = "Upload Device Picture")]
        public IFormFile? DevicePictureFile { get; set; }

        [Display(Name = "Buying Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BuyingDate { get; set; }

        [Display(Name = "Age (Months)")]
        [Range(0, 500, ErrorMessage = "Please enter a valid age")]
        public int DeviceAge { get; set; }

        [Display(Name = "Regular Customer?")]
        public bool IsRegular { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [Required(ErrorMessage = "At least one service must be selected")]
        [Display(Name = "Select Services")]
        public List<int> ServiceList { get; set; } = new List<int>();
    }
}