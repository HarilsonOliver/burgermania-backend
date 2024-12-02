using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
    private readonly AppDbContext _context;

    public StatusController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Status>> GetStatuses()
    {
        return Ok(_context.Statuses.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<Status> GetStatus(int id)
    {
        var status = _context.Statuses.Find(id);
        if (status == null) return NotFound();
        return Ok(status);
    }

    [HttpPost]
    public ActionResult<Status> CreateStatus(Status status)
    {
        _context.Statuses.Add(status);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetStatus), new { id = status.Id }, status);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStatus(int id, Status status)
    {
        if (id != status.Id) return BadRequest();
        _context.Entry(status).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStatus(int id)
    {
        var status = _context.Statuses.Find(id);
        if (status == null) return NotFound();
        _context.Statuses.Remove(status);
        _context.SaveChanges();
        return NoContent();
    }
}
