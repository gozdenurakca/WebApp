using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Branch
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BranchID { get; set; }

    [Required]
    [StringLength(100)]
    public string BranchName { get; set; }

    [StringLength(255)]
    public string Address { get; set; }

    [StringLength(15)]
    public string PhoneNumber { get; set; }
}