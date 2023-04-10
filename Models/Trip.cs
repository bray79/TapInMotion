using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TapInMotion.Models;

public class Trip
{
    [Key]
    public int TripID { get; set; }

    [Required]
    public int VehicleID { get; set; }
    public virtual Vehicle? Vehicle { get; set; } //= null!;

    // [ForeignKey(nameof(Student))]

    [Required]
    public int SchoolID { get; set; }
    public virtual School? School { get; set; } //= null!;

    [Required]
    public int StudentID { get; set; }

    public virtual Student? Student { get; set; } //= null!;

    [Required]
    public int StartStationID { get; set; }
    public virtual Station? StartStation { get; set; }// = null!;

    [Required]
    public int EndStationID { get; set; }
    public virtual Station? EndStation { get; set; }// = null!;

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; set; } = DateTime.Now;

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; set; } = DateTime.Now.AddMinutes(30);
}