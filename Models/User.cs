using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    [Required]
    [StringLength(20)]
    [RegularExpression("^(Trainer|Student|BranchAdmin|MajorAdmin)$", ErrorMessage = "Invalid UserType")]
    public string UserType { get; set; }
}