using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportSchoolProject.Models;

public class Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CourseID { get; set; }

    [Required]
    [StringLength(100)]
    public string CourseName { get; set; }

    [Required]
    public int TrainerID { get; set; }

    [Required]
    public int BranchID { get; set; }

    [StringLength(50)]
    public string AgeRange { get; set; }

    [StringLength(20)]
    public string Day { get; set; }

    // Navigation properties
    public virtual Trainer Trainer { get; set; }
    public virtual Branch Branch { get; set; }
}