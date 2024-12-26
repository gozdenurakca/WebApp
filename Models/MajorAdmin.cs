using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MajorAdmin
{
    [Key]
    [ForeignKey("User")]
    public int AdminID { get; set; }

    [Required]
    [StringLength(100)]
        public string FullName { get; set; }
        public string AssignedBranches { get; set; }
        public List<string> AssignedBranchesList { get; set; } // New List to hold branches
        public int NumberOfPeople { get; set; }
        public decimal MonthlyIncome { get; set; }
        public decimal AnnualIncome { get; set; }
}