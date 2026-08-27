namespace MantenimientoAutomotrizAPI.Models
{
    public class Mantenimiento
    {
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Costo { get; set; }
        public DateTime Fecha { get; set; }

        // Propiedad de navegación
        public Vehiculo? Vehiculo { get; set; }
    }
}