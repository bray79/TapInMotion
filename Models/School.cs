using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TapInMotion.Models;

public class School
{
    public int SchoolID { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:N5}", ApplyFormatInEditMode = true)]
    [Column(TypeName = "decimal(8,5)")]
    public decimal Longitude { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:N5}", ApplyFormatInEditMode = true)]
    [Column(TypeName = "decimal(8,5)")]
    public decimal Latitude { get; set; }
    public int MapZoom { get; set; } = 4;

    [Required]
    public string Alias { get; set; } = default!;

    [Required]
    public string Name { get; set; } = default!;
    public string? State { get; set; }
    public string? City { get; set; }
    public virtual ICollection<Station> Stations { get; set; } = new List<Station>();
    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    public virtual ICollection<Administrator> Administrators { get; set; } =
        new List<Administrator>();
}
