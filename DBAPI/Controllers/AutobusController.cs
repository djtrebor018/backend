using DBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutobusController : ControllerBase
    {
        private readonly PROYECTO_FINNALContext _dbcontext;

        public AutobusController(PROYECTO_FINNALContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        public IActionResult GetAutobus()
        {

            try
            {
                var autobus = _dbcontext.Autobus.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = autobus });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]

        public IActionResult Registrar_Autobus([FromBody] Autobus autobus)
        {
            try
            {
                _dbcontext.Autobus.Add(autobus);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "autobus registrado con exito", });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
