namespace PJATK_APBD_Cw4_s32188.DTOs;

public record PCWithComponentsResponse(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<PCComponentResponse> Components
);