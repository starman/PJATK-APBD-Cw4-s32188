using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw4_s32188.Models;

[Table("Component")]
public class Component
{
    [Key]
    [Column(TypeName = "char(10)")]
    public string Code { get; set; } = string.Empty;
    
    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public int ComponentManufacturerId { get; set; }
    
    public int ComponentTypeId { get; set; }
    
    [ForeignKey(nameof(ComponentManufacturerId))]
    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;
    
    [ForeignKey(nameof(ComponentTypeId))]
    public ComponentType ComponentType { get; set; } = null!;
    
    public IEnumerable<PCComponent> PCComponents { get; set; } = [];
}