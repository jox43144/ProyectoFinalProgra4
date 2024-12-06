using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Db;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios/5
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<bool>> GetAutorizacion(String email, String password)
        {
            try{
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(password));

            if (usuario == null)
            {
                return false;
            }

            return true;
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
        
  
        [HttpPost]
        public async Task<ActionResult<Usuarios>> PostUsuarios(Usuarios usuario)
        {
            try{
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        private bool UsuariosExists(long id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}