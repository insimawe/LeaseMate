using LeaseMate.Core.Entities;
using LeaseMate.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaseMate.Infrastructure.Services;

public class ContractService
{
    private readonly AppDbContext _db;

    public ContractService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Contract>> GetAllAsync()
    {
        return await _db.Contracts
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task<Contract?> GetByIdAsync(int id)
    {
        return await _db.Contracts
            .Include(x => x.Attachments)
            .Include(x => x.GeneratedDocuments)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Contract> CreateAsync(Contract contract)
    {
        contract.CreatedAt = DateTime.UtcNow;
        contract.ContractNumber = string.IsNullOrWhiteSpace(contract.ContractNumber)
            ? GenerateContractNumber()
            : contract.ContractNumber;

        _db.Contracts.Add(contract);
        await _db.SaveChangesAsync();

        return contract;
    }

    public async Task UpdateAsync(Contract contract)
    {
        contract.UpdatedAt = DateTime.UtcNow;

        _db.Contracts.Update(contract);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var contract = await _db.Contracts.FindAsync(id);

        if (contract is null)
            return;

        _db.Contracts.Remove(contract);
        await _db.SaveChangesAsync();
    }

    private static string GenerateContractNumber()
    {
        return $"LM-{DateTime.Now:yyyyMMdd-HHmmss}";
    }
}