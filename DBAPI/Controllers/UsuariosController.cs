using DBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly PROYECTO_FINNALContext _dbcontext;

        public UsuariosController(PROYECTO_FINNALContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        public IActionResult usuarios()
        {


            try
            {

                var usuarios = _dbcontext.Usuarios.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = usuarios });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }

        [HttpPost]
        public IActionResult Registrar([FromBody] Usuarios usuarios)
        {

            try
            {

                _dbcontext.Usuarios.Add(usuarios);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "usuario registrado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("id")]

        public async Task<IActionResult> put(int id, [FromBody] Usuarios usuario)
        {
            try
            {
                if (id != usuario.IdUsuario)
                {
                    return NotFound();
                }
                usuario.Usuario = usuario.Usuario;
                usuario.Contraseña = usuario.Contraseña;
                usuario.Nombre = usuario.Nombre;
                usuario.Apellido = usuario.Apellido;
                usuario.Email = usuario.Email;
                usuario.Cedula = usuario.Cedula;

                _dbcontext.Entry(usuario).State = EntityState.Modified;
                await _dbcontext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "usuario modificado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        
       

    }
}


