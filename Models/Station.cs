using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TapInMotion.Models;

public class Station
{
    public int StationID { get; set; }
    [Required]
    public int SchoolID { get; set; }

    [JsonIgnore]
    public virtual School? School { get; set; } 
    public string? Name { get; set; }

    [Display(Name = "Bike Capacity")]
    public int BikeCapacity { get; set; } = 30;

    [Display(Name = "Scooter Capacity")]
    public int ScooterCapacity { get; set; } = 30;

    [Display(Name = "Skateboard Capacity")]
    public int SkateboardCapacity { get; set; } = 30;

    [Required]
    [DisplayFormat(DataFormatString = "{0:N5}", ApplyFormatInEditMode = true)]
    [Column(TypeName = "decimal(8,5)")]
    public decimal Longitude { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:N5}", ApplyFormatInEditMode = true)]
    [Column(TypeName = "decimal(8,5)")]
    public decimal Latitude { get; set; }
    [InverseProperty("CurrentStation")]
    public virtual ICollection<Vehicle> AvailableVehicles { get; set; } =  new List<Vehicle>();
}
