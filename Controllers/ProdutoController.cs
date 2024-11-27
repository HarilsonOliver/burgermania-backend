
using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetProdutos()
        {
            return Ok(_context.Produtos.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetProduto(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> CreateProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(int id, Produto produto)
        {
            if (id != produto.Id) return BadRequest();
            _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null) return NotFound();
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return NoContent();
        }
    }

