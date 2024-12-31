using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportSchoolProject.Models;
using SportSchoolProject.Models;

public class Student
{
    [Key]
    [ForeignKey("User")]
    public int StudentID { get; set; }

    public string UserId { get; set; }  

    [Required]
    [StringLength(100)]
    public string FullName { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public int BranchID { get; set; }

    public int? TrainerID { get; set; }

    public int? CourseID { get; set; }

    // Navigation properties
    public  User User { get; set; }
    public virtual Branch Branch { get; set; }
    public virtual Trainer Trainer { get; set; }
    public virtual Course Course { get; set; }
}