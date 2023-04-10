using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TapInMotion.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<TapInMotion.Models.Student> Student { get; set; } = default!;

    public DbSet<TapInMotion.Models.School> School { get; set; } = default!;

    public DbSet<TapInMotion.Models.Vehicle> Vehicle { get; set; } = default!;

    public DbSet<TapInMotion.Models.Station> Station { get; set; } = default!;

    public DbSet<TapInMotion.Models.Station> Trip { get; set; } = default!;
    public DbSet<TapInMotion.Models.Administrator> Administrator { get; set; } = default!;
}
