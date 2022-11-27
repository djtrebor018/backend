using DBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoferController : ControllerBase
    {
        private readonly PROYECTO_FINNALContext _dbcontext;
        public ChoferController(PROYECTO_FINNALContext _context)
        {
            _dbcontext = _context;
        }
        [HttpPost]
        public IActionResult Registrar_chofer([FromBody] Choferes chofer)
        {
            try
            {
                _dbcontext.Choferes.Add(chofer);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "chofer registrado con exito", });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult choferes()
        {


            try
            {

                var choferes = _dbcontext.Choferes.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = choferes });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }
        [HttpPut("id")]
        public async Task<IActionResult> put(int id, [FromBody] Choferes chofer)
        {
            try
            {
                if (id != chofer.IdChofer)
                {
                    return NotFound();
                }
                chofer.Nombre = chofer.Nombre;
                chofer.Apellido = chofer.Apellido;
                chofer.Cedula = chofer.Cedula;
                chofer.CategoriaLicencia = chofer.CategoriaLicencia;
                chofer.ExpiracionLicencia = chofer.ExpiracionLicencia;
                chofer.Autobus = chofer.Autobus;

                _dbcontext.Entry(chofer).State = EntityState.Modified;
                await _dbcontext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = " chofer modificado con exito", });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
