using System.ComponentModel.DataAnnotations;

namespace PJATK_APBD_Cw4_s32188.DTOs;

public record UpdatePCRequest(
    [MaxLength(50)] string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);