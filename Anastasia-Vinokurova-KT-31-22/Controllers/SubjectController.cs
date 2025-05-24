using Microsoft.AspNetCore.Mvc;
using Anastasia_Vinokurova_KT_31_22.Models;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService _svc;
    public SubjectController(ISubjectService svc) => _svc = svc;

    /// <summary>List all (non-deleted) subjects</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var list = await _svc.GetAllAsync(ct);
        return Ok(list);
    }

    /// <summary>Get by id</summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, CancellationToken ct)
    {
        var s = await _svc.GetByIdAsync(id, ct);
        if (s == null) return NotFound();
        return Ok(s);
    }

    /// <summary>Create new subject</summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Subject subject, CancellationToken ct)
    {
        var created = await _svc.CreateAsync(subject, ct);
        return CreatedAtAction(nameof(Get), new { id = created.SubjectId }, created);
    }

    /// <summary>Update subject name</summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Subject dto, CancellationToken ct)
    {
        var updated = await _svc.UpdateAsync(id, dto.SubjectName, ct);
        return Ok(updated);
    }

    /// <summary>Soft-delete</summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _svc.DeleteAsync(id, ct);
        return NoContent();
    }
}
