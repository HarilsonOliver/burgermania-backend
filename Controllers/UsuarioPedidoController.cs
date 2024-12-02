using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UsuarioPedidoController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuarioPedidoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UsuarioPedido>> GetUsuarioPedidos()
    {
        return Ok(_context.UsuarioPedidos.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<UsuarioPedido> GetUsuarioPedido(int id)
    {
        var usuarioPedido = _context.UsuarioPedidos.Find(id);
        if (usuarioPedido == null) return NotFound();
        return Ok(usuarioPedido);
    }

    [HttpPost]
    public ActionResult<UsuarioPedido> CreateUsuarioPedido(UsuarioPedido usuarioPedido)
    {
        _context.UsuarioPedidos.Add(usuarioPedido);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUsuarioPedido), new { id = usuarioPedido.Id }, usuarioPedido);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUsuarioPedido(int id, UsuarioPedido usuarioPedido)
    {
        if (id != usuarioPedido.Id) return BadRequest();
        _context.Entry(usuarioPedido).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUsuarioPedido(int id)
    {
        var usuarioPedido = _context.UsuarioPedidos.Find(id);
        if (usuarioPedido == null) return NotFound();
        _context.UsuarioPedidos.Remove(usuarioPedido);
        _context.SaveChanges();
        return NoContent();
    }
}
