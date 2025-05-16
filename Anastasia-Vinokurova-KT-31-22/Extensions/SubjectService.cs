// SubjectService.cs
using Microsoft.EntityFrameworkCore;
using Anastasia_Vinokurova_KT_31_22.Databases;
using Anastasia_Vinokurova_KT_31_22.Models;

public class SubjectService : ISubjectService
{
    private readonly PrepodDbContext _db;
    public SubjectService(PrepodDbContext db) => _db = db;

    public async Task<Subject> CreateAsync(Subject subject, CancellationToken ct)
    {
        _db.Set<Subject>().Add(subject);
        await _db.SaveChangesAsync(ct);
        return subject;
    }

    public async Task<Subject> UpdateAsync(int id, string newName, CancellationToken ct)
    {
        var subj = await _db.Set<Subject>().FindAsync(new object[] { id }, ct);
        if (subj == null || subj.IsDeleted) throw new KeyNotFoundException();
        subj.SubjectName = newName;
        await _db.SaveChangesAsync(ct);
        return subj;
    }

    public async Task DeleteAsync(int id, CancellationToken ct)
    {
        var subj = await _db.Set<Subject>().FindAsync(new object[] { id }, ct);
        if (subj == null || subj.IsDeleted) throw new KeyNotFoundException();
        subj.IsDeleted = true;
        await _db.SaveChangesAsync(ct);
    }

    public Task<Subject> GetByIdAsync(int id, CancellationToken ct) =>
        _db.Set<Subject>().FirstOrDefaultAsync(s => s.SubjectId == id, ct);

    public Task<List<Subject>> GetAllAsync(CancellationToken ct) =>
        _db.Set<Subject>().ToListAsync(ct);
}
