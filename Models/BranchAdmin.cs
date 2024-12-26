using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BranchAdmin
{
    [Key]
    [ForeignKey("User")]
    public int BranchAdminID { get; set; }

    [Required]
    public int BranchID { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; }

    // Navigation properties
    public virtual User User { get; set; }
    public virtual Branch Branch { get; set; }
}