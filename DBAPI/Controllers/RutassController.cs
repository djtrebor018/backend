using DBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutassController : ControllerBase
    {

        private readonly PROYECTO_FINNALContext _dbcontext;

        public RutassController(PROYECTO_FINNALContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        public IActionResult Getrutas() {

            try
            {
                var ruta = _dbcontext.Rutas.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = ruta });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }

        [HttpPut("id")]
        public async Task<IActionResult> put(int id, [FromBody] Rutas ruta)
        {
            try
            {
                if (id != ruta.IdRuta)
                {
                    return NotFound();
                }
                ruta.Origen = ruta.Origen;
                ruta.Destino = ruta.Destino;
                ruta.Estatus = ruta.Estatus;

                _dbcontext.Entry(ruta).State = EntityState.Modified;
                await _dbcontext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = " ruta modificada con exito", });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public IActionResult Registrar_Ruta([FromBody] Rutas ruta)
        {
            try
            {
                _dbcontext.Rutas.Add(ruta);
                _dbcontext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ruta registrada con exito", });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        }
    }

