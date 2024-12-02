using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class PedidoController : ControllerBase
{
    private readonly AppDbContext _context;

    public PedidoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pedido>> GetPedidos()
    {
        return Ok(_context.Pedidos.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<Pedido> GetPedido(int id)
    {
        var pedido = _context.Pedidos.Find(id);
        if (pedido == null) return NotFound();
        return Ok(pedido);
    }

    [HttpPost]
    public ActionResult<Pedido> CreatePedido(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, pedido);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePedido(int id, Pedido pedido)
    {
        if (id != pedido.Id) return BadRequest();
        _context.Entry(pedido).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePedido(int id)
    {
        var pedido = _context.Pedidos.Find(id);
        if (pedido == null) return NotFound();
        _context.Pedidos.Remove(pedido);
        _context.SaveChanges();
        return NoContent();
    }
}
