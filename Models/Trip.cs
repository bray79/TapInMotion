using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TapInMotion.Models;

public class Trip
{
    [Key]
    public int TripID { get; set; }

    public int VehicleID { get; set; }
    public virtual Vehicle Vehicle { get; set; } = default!;

    // [ForeignKey(nameof(Student))]

    public int SchoolID { get; set; }
    public virtual School School { get; set; } = default!;

    public int StudentID { get; set; }

    public virtual Student Student { get; set; } = default!;

    public int StartStationID { get; set; }
    public virtual Station StartStation { get; set; } = default!;

    public int EndStationID { get; set; }
    public virtual Station EndStation { get; set; } = default!;

    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; set; } = DateTime.Now;

    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; set; } = DateTime.Now.AddMinutes(30);
}