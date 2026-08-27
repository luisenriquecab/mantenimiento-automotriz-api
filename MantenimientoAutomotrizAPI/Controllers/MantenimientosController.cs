using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MantenimientoAutomotrizAPI.Data;
using MantenimientoAutomotrizAPI.Models;

namespace MantenimientoAutomotrizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MantenimientosController(AppDbContext context)
        {
            _context = context;
        }

        //POST: api/Mantenimientos (registra un nuevo servicio)
        [HttpPost]
        public async Task<ActionResult<Mantenimiento>> PostMantenimiento(Mantenimiento mantenimiento)
        {
            //valida de forma robusta que el vehiculo realmente exista en la base de datos
            var vehiculoExiste = await _context.Vehiculos.AnyAsync(v => v.Id == mantenimiento.VehiculoId);
            if (!vehiculoExiste)
            {
                return NotFound("El vehículo especificado no existe en el sistema.");
            }

            _context.Mantenimientos.Add(mantenimiento);
            await _context.SaveChangesAsync();

            return Ok(mantenimiento);
        }
    }
}