using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportSchoolProject.Models;

public class Progress
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProgressID { get; set; }

    [Required]
    public int StudentID { get; set; }

    [Required]
    public int CourseID { get; set; }

    public string ProgressDetail { get; set; }

    // Navigation properties
    public virtual Student Student { get; set; }
    public virtual Course Course { get; set; }
}