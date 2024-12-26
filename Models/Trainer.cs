using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportSchoolProject.Models;

public class Trainer
{
    [Key]
    [ForeignKey("User")]
    public int TrainerID { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; }

    [StringLength(100)]
    public string Specialization { get; set; }

    [Required]
    public int BranchID { get; set; }

    // Navigation properties
    public virtual User User { get; set; }
    public virtual Branch Branch { get; set; }
}