using Anastasia_Vinokurova_KT_31_22.Models;

public interface ISubjectService
{
    Task<Subject> CreateAsync(Subject subject, CancellationToken ct);
    Task<Subject> UpdateAsync(int id, string newName, CancellationToken ct);
    Task DeleteAsync(int id, CancellationToken ct);  // soft-delete
    Task<Subject> GetByIdAsync(int id, CancellationToken ct);
    Task<List<Subject>> GetAllAsync(CancellationToken ct);
}