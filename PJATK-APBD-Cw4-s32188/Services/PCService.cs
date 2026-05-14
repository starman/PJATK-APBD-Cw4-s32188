using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw4_s32188.DTOs;
using PJATK_APBD_Cw4_s32188.Exceptions;
using PJATK_APBD_Cw4_s32188.Infrastructure;
using PJATK_APBD_Cw4_s32188.Models;

namespace PJATK_APBD_Cw4_s32188.Services;

public class PCService(DatabaseContext ctx) : IPCService
{
    public async Task<IEnumerable<PCResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await ctx.PCs.Select(pc => new PCResponse(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
        )).ToListAsync(cancellationToken);
    }

    public async Task<PCWithComponentsResponse> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.PCs
            .Where(pc => pc.Id == id)
            .Select(pc => new PCWithComponentsResponse(
                pc.Id,
                pc.Name,
                pc.Weight,
                pc.Warranty,
                pc.CreatedAt,
                pc.Stock,

                pc.PCComponents
                    .Select(pcComponent => new PCComponentResponse(
                        pcComponent.Amount,

                        new ComponentResponse(
                            pcComponent.Component.Code,
                            pcComponent.Component.Name,
                            pcComponent.Component.Description,

                            new ComponentManufacturerResponse(
                                pcComponent.Component.ComponentManufacturer.Id,
                                pcComponent.Component.ComponentManufacturer.Abbreviation,
                                pcComponent.Component.ComponentManufacturer.FullName,
                                pcComponent.Component.ComponentManufacturer.FoundationDate
                            ),

                            new ComponentTypeResponse(
                                pcComponent.Component.ComponentType.Id,
                                pcComponent.Component.ComponentType.Abbreviation,
                                pcComponent.Component.ComponentType.Name
                            )
                        )
                    ))
                    .ToList()
            )).FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException($"PC with id {id} not found");
    }

    public async Task<PCResponse> AddAsync(CreatePCRequest request, CancellationToken cancellationToken)
    {
        var pc = new PC()
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };
        
        ctx.Add(pc);
        await ctx.SaveChangesAsync(cancellationToken);
        
        return new PCResponse(pc.Id, pc.Name, pc.Weight, pc.Warranty, pc.CreatedAt, pc.Stock);
    }

    public async Task UpdateAsync(int id, UpdatePCRequest request, CancellationToken cancellationToken)
    {
        int affectedRows = await ctx.PCs.Where(pc => pc.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(p => p.Name, request.Name)
                .SetProperty(p => p.Weight, request.Weight)
                .SetProperty(p => p.Warranty, request.Warranty)
                .SetProperty(p => p.CreatedAt, request.CreatedAt)
                .SetProperty(p => p.Stock, request.Stock),
                cancellationToken
            );

        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        int affectedRows = await ctx.PCs
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
    }
}