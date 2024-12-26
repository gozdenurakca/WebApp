using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Report
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReportID { get; set; }

    [Required]
    public int StudentID { get; set; }

    [Required]
    public int TrainerID { get; set; }

    public string ReportContent { get; set; }

    // Navigation properties
    public virtual Student Student { get; set; }
    public virtual Trainer Trainer { get; set; }
}