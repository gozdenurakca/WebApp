using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportSchoolProject.Models;

public class Session
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SessionID { get; set; }

    [Required]
    public int CourseID { get; set; }

    [Required]
    public int TrainerID { get; set; }

    [Required]
    public DateTime SessionDate { get; set; }

    public int? Duration { get; set; }

    // Navigation properties
    public virtual Course Course { get; set; }
    public virtual Trainer Trainer { get; set; }
}