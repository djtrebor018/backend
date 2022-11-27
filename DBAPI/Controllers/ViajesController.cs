using DBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajesController : ControllerBase
    {
        private readonly PROYECTO_FINNALContext _dbcontext;
        public ViajesController(PROYECTO_FINNALContext _context)
        {
            _dbcontext = _context;
        }
        [HttpPost]
        public IActionResult registrar_viaje([FromBody] Viajes viaje)
        {
            try
            {
                _dbcontext.Viajes.Add(viaje);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "viaje registrado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Viajes()
        {
            try
            {
                var viajes = _dbcontext.Viajes.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = viajes });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }
    }
}
