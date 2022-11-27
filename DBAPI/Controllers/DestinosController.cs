using DBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinosController : ControllerBase
    {
        private readonly PROYECTO_FINNALContext _dbcontext;
        public DestinosController(PROYECTO_FINNALContext _context) { 
            _dbcontext = _context;
        }
        [HttpPost]
        public IActionResult destino([FromBody] Destinos destino)
        {
            try
            {
                _dbcontext.Destinos.Add(destino);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "destino registrado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public  IActionResult destinos()
        {
            try
            {
               var destinos = _dbcontext.Destinos.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = destinos });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }
   
    }
}
