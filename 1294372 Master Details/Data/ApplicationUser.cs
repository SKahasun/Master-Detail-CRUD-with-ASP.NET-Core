using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class ApplicationUser : IdentityUser
{
    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
    [Display(Name = "Full Name")]
    public string Name { get; set; } = default!;

    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    public string Phone { get; set; } = default!;

    [Required]
    [StringLength(50)]
    public string Role { get; set; } = default!;

    [Required]
    [StringLength(255)]
    public string Address { get; set; } = default!;
}