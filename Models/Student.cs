using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TapInMotion.Models;

public class Student
{
    public int StudentID { get; set; }

    [Required]
    [Display(Name = "User")]
    [DisplayFormat(NullDisplayText = "No User Selected", ApplyFormatInEditMode = true)]
    public string? UserID { get; set; }
    public virtual IdentityUser? User { get; set; }

    public int StudentNumber { get; set; }

    [Required]
    // [ForeignKey("School")]
    [Display(Name = "School")]
    [DisplayFormat(NullDisplayText = "No School Selected", ApplyFormatInEditMode = true)]
    public int SchoolID { get; set; }
    public virtual School? School { get; set; }
    public string? Name { get; set; }

    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; } = DateTime.Now;
    public string? Major { get; set; }
    public string? Minor { get; set; }
    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
