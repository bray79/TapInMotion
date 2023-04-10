using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TapInMotion.Models;

public enum VehicleType  {
    Skateboard,
    Bicycle,
    Scooter,
    OneWheel
}
public class Vehicle
{
    public int VehicleID { get; set; }
    [Required]
    public int SchoolID { get; set; } 
    public virtual School School {get;set;} = default!;
    [Required]
    public VehicleType Type { get; set; }
    [DisplayFormat(DataFormatString = "{0:N5}", ApplyFormatInEditMode = true)]
    [Column(TypeName ="decimal(8,5)")]
    public decimal Longitude {get; set;} 

    [DisplayFormat(DataFormatString = "{0:N5}", ApplyFormatInEditMode = true)]
    [Column(TypeName ="decimal(8,5)")]
    public decimal Latitude {get; set;}
    public int PreviousStationID {get; set;} 
    public virtual Station PrevisionStation {get;set;} = default!;
    public int? CurrentStationID {get; set;}
    public virtual Station? CurrentStation {get;set;}
    public virtual ICollection<Trip> TripHistory {get;set;} = default!;
}
