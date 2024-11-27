
using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return Ok(_context.Usuarios.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult<Usuario> CreateUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id) return BadRequest();
            _context.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return NotFound();
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return NoContent();
        }
    }

