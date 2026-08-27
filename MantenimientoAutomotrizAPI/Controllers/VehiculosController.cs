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

        // El constructor inyecta nuestra base de datos
        public VehiculosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Vehiculos (Obtener todos los vehículos con su historial)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculos()
        {
            // El .Include hace el JOIN automático en SQL Server
            return await _context.Vehiculos.Include(v => v.Mantenimientos).ToListAsync();
        }

        // POST: api/Vehiculos (Registrar un nuevo vehículo)
        [HttpPost]
        public async Task<ActionResult<Vehiculo>> PostVehiculo(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();

            return Ok(vehiculo);
        }
    }
}