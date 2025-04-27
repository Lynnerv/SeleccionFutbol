using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeleccionFutbol.Models;

namespace SeleccionFutbol.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Assignment> Assignments { get; set; } // Si tienes la tabla
    
    public DbSet<Player> Players { get; set; }

    public DbSet<Team> Teams { get; set; }

}
