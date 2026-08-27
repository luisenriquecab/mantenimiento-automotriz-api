using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MantenimientoAutomotrizAPI.Data;
using MantenimientoAutomotrizAPI.Models;

namespace MantenimientoAutomotrizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly AppDbContext _context;

        //el constructor inyecta nuestra base de datos
        public VehiculosController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/Vehiculos (obtiene todos los vehiculos con su historial)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculos()
        {
            //el .Include hace el JOIN automatico en SQL Server
            return await _context.Vehiculos.Include(v => v.Mantenimientos).ToListAsync();
        }

        //POST: api/Vehiculos (registra un nuevo vehículo)
        [HttpPost]
        public async Task<ActionResult<Vehiculo>> PostVehiculo(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();

            return Ok(vehiculo);
        }
    }
}