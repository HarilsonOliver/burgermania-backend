
using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetCategorias()
        {
            return Ok(_context.Categorias.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Categoria> GetCategoria(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult<Categoria> CreateCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id) return BadRequest();
            _context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoria(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null) return NotFound();
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return NoContent();
        }
    }

