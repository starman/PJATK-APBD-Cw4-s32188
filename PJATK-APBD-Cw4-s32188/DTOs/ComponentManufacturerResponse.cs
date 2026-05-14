namespace PJATK_APBD_Cw4_s32188.DTOs;

public record ComponentManufacturerResponse(
    int Id,
    string Abbreviation,
    string FullName,
    DateOnly FoundationDate
);