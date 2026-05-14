namespace PJATK_APBD_Cw4_s32188.DTOs;

public record ComponentResponse(
    string Code,
    string Name,
    string Description,
    ComponentManufacturerResponse Manufacturer,
    ComponentTypeResponse Type
);