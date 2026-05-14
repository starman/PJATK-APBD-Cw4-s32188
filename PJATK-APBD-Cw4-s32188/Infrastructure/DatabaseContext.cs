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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PC>().HasData([
            new PC()
            {
                Id = 1,
                Name = "Office Computer",
                Weight = 11.5f,
                Warranty = 24,
                CreatedAt = new DateTime(2026, 5, 14, 9, 0, 0),
                Stock = 12
            },
            new PC()
            {
                Id = 2,
                Name = "Games Machine",
                Weight = 13.5f,
                Warranty = 36,
                CreatedAt = new DateTime(2026, 5, 14, 15, 0, 0),
                Stock = 3
            },
            new PC()
            {
                Id = 3,
                Name = "Universal Computer",
                Weight = 11.0f,
                Warranty = 48,
                CreatedAt = new DateTime(2026, 5, 14, 15, 30, 0),
                Stock = 6
            }
        ]);

        modelBuilder.Entity<ComponentManufacturer>().HasData([
            new  ComponentManufacturer()
            {
                Id = 1,
                Abbreviation = "AMD",
                FullName = "Advanced Micro Devices",
                FoundationDate = new DateOnly(1969, 05, 01),
            },
            new  ComponentManufacturer()
            {
                Id = 2,
                Abbreviation = "NV",
                FullName = "Nvidia Corporation",
                FoundationDate = new DateOnly(1993, 04, 05),
            },
            new  ComponentManufacturer()
            {
                Id = 3,
                Abbreviation = "COR",
                FullName = "Corsair Gaming Inc.",
                FoundationDate = new DateOnly(1994, 01, 01),
            }
        ]);

        modelBuilder.Entity<ComponentType>().HasData([
            new ComponentType()
            {
                Id = 1,
                Abbreviation = "CPU",
                Name = "Processor"
            },
            new ComponentType()
            {
                Id = 2,
                Abbreviation = "GPU",
                Name = "Graphics Card"
            },
            new ComponentType()
            {
                Id = 3,
                Abbreviation = "RAM",
                Name = "Memory"
            }
        ]);

        modelBuilder.Entity<Component>().HasData([
            new Component()
            {
                Code = "CPU4567890",
                Name = "Ryzen 7800x",
                Description = "Super fast CPU",
                ComponentManufacturerId = 1,
                ComponentTypeId = 1
            },
            new Component()
            {
                Code = "GPU4567890",
                Name = "RTX 4090",
                Description = "High-end graphics card",
                ComponentManufacturerId = 2,
                ComponentTypeId = 2
            },
            new Component()
            {
                Code = "RAM4567890",
                Name = "Corsair DDR 5 16GB",
                Description = "16GB RAM module",
                ComponentManufacturerId = 3,
                ComponentTypeId = 3
            }
        ]);

        modelBuilder.Entity<PCComponent>().HasData([
            new PCComponent()
            {
                PCId = 1,
                ComponentCode = "CPU4567890",
                Amount = 1
            },
            new PCComponent()
            {
                PCId = 1,
                ComponentCode = "RAM4567890",
                Amount = 2
            },
            new PCComponent()
            {
                PCId = 2,
                ComponentCode = "GPU4567890",
                Amount = 1
            }
        ]);
        
        


    }
}