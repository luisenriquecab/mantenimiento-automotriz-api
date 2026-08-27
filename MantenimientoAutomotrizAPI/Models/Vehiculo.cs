namespace MantenimientoAutomotrizAPI.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Anio { get; set; }

        // Relación: Un vehículo puede tener muchos mantenimientos
        public List<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();
    }
}