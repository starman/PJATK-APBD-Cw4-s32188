using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw4_s32188.Models;

namespace PJATK_APBD_Cw4_s32188.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<PC> PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
}