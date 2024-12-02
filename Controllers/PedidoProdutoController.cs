using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class PedidoProdutoController : ControllerBase
{
    private readonly AppDbContext _context;

    public PedidoProdutoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PedidoProduto>> GetPedidoProdutos()
    {
        return Ok(_context.PedidoProdutos.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<PedidoProduto> GetPedidoProduto(int id)
    {
        var pedidoProduto = _context.PedidoProdutos.Find(id);
        if (pedidoProduto == null) return NotFound();
        return Ok(pedidoProduto);
    }

    [HttpPost]
    public ActionResult<PedidoProduto> CreatePedidoProduto(PedidoProduto pedidoProduto)
    {
        _context.PedidoProdutos.Add(pedidoProduto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetPedidoProduto), new { id = pedidoProduto.Id }, pedidoProduto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePedidoProduto(int id, PedidoProduto pedidoProduto)
    {
        if (id != pedidoProduto.Id) return BadRequest();
        _context.Entry(pedidoProduto).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePedidoProduto(int id)
    {
        var pedidoProduto = _context.PedidoProdutos.Find(id);
        if (pedidoProduto == null) return NotFound();
        _context.PedidoProdutos.Remove(pedidoProduto);
        _context.SaveChanges();
        return NoContent();
    }
}
